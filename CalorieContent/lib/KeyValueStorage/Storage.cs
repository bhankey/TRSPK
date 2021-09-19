using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CalorieContent.lib.KeyValueStorage
{
    public class Storage : IStorage
    {
        private FileStream db = null;

        private string _pathToFile;

        private static Mutex _mutex = new Mutex();

        public Storage(string pathToFile)
        {
            _pathToFile =  pathToFile;
            OpenFile();
        }

        ~Storage()
        {
            db.Flush();
            db.Close();
        }

        private void OpenFile()
        {
            db = File.Open(_pathToFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }

        public bool TryGetString(string key, out string value)
        {
            try
            {
                _mutex.WaitOne();

                var reader = new StreamReader(db);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var isSucceed = TryParseString(line, out string dataKey, out value);
                    
                    if (isSucceed && dataKey == key)
                    {
                        return true;
                    }
                }
                value = null;

                return false;

            }
            finally
            {
                db.Seek(0, SeekOrigin.Begin);
                
                _mutex.ReleaseMutex();
            }
        }
        private static bool ValidateQuotes(in string line, out string unQuotedString)
        {
            unQuotedString = null;
            
            if (line.StartsWith('\"') && line.EndsWith('\"'))
            {
                unQuotedString = line.Substring(1, line.Length - 2);
                
                return true;
            }

            return false;
        }

        private static bool TryParseString(string line, out string key, out string value)
        {
            key = null;
            value = null;
            
            var delimiter = line.IndexOf("\":\"");
            if (delimiter <= 0)
            {
                return false;
            }

            if (!ValidateQuotes(line.Substring(0, delimiter + 1), out key) ||
                !ValidateQuotes(line.Substring(delimiter + 2), out value))
            {
                return false;
            }


            return true;
        }

        public void SetString(string key, string value)
        {
            try
            {
                _mutex.WaitOne();

                InternalTryDelete(key);
                
                var writer = new StreamWriter(db);

                long endPoint = db.Length;

                db.Seek(endPoint, SeekOrigin.Begin);
                writer.WriteLine("\"{0}\":\"{1}\"", key, value);
                writer.Flush();
            }
            finally
            {
                db.Seek(0, SeekOrigin.Begin);
                
                _mutex.ReleaseMutex();
            }
        }

        private bool InternalTryDelete(string key)
        {
            var reader = new StreamReader(db);

            var isDeleted = false;
            using (var tmpWriter = new StreamWriter(_pathToFile + "tmp"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string dataKey;
                    var success = TryParseString(line, out dataKey, out _);

                    if (!success || dataKey.Equals(key))
                    {
                        if (dataKey == key)
                        {
                            isDeleted = true;
                        }
                        continue;
                    }

                    tmpWriter.WriteLine(line);
                }
                
                db.Close();
                File.Delete(_pathToFile);
                tmpWriter.Close();
                File.Move( _pathToFile + "tmp", _pathToFile);
            }
            
            OpenFile();

            return isDeleted;
        }

        public bool TryDelete(string key)
        {
            try
            {
                _mutex.WaitOne();

                return InternalTryDelete(key);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}