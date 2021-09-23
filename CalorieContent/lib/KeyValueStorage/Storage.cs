using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CalorieContent.lib.KeyValueStorage
{
    public class Storage : IStorage
    {
        private const int CountOfDataBases = 2;

        private const string _basePathToFile = "C:\\Users\\Sergey\\RiderProjects\\TRSPK\\CalorieContent\\DB";


        private static readonly FileStream[] db = new FileStream[CountOfDataBases];

        private static readonly Mutex[] _mutex = new Mutex[CountOfDataBases];

        static Storage()
        {
            for (var i = 0; i < CountOfDataBases; i++)
            {
                db[i] = File.Open(_basePathToFile + i, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                _mutex[i] = new Mutex();
            }
        }

        public bool TryGetString(int DBNum, string key, out string value)
        {
            try
            {
                _mutex[DBNum].WaitOne();

                var reader = new StreamReader(db[DBNum]);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var isSucceed = TryParseString(line, out var dataKey, out value);

                    if (isSucceed && dataKey == key) return true;
                }

                value = null;

                return false;
            }
            finally
            {
                db[DBNum].Seek(0, SeekOrigin.Begin);

                _mutex[DBNum].ReleaseMutex();
            }
        }

        public void SetString(int DBNum, string key, string value)
        {
            try
            {
                _mutex[DBNum].WaitOne();

                InternalTryDelete(DBNum, key);

                var writer = new StreamWriter(db[DBNum]);

                var endPoint = db[DBNum].Length;

                db[DBNum].Seek(endPoint, SeekOrigin.Begin);
                writer.WriteLine("\"{0}\":\"{1}\"", key, value);
                writer.Flush();
            }
            finally
            {
                db[DBNum].Seek(0, SeekOrigin.Begin);

                _mutex[DBNum].ReleaseMutex();
            }
        }

        public bool TryDelete(int DBNum, string key)
        {
            try
            {
                _mutex[DBNum].WaitOne();

                return InternalTryDelete(DBNum, key);
            }
            finally
            {
                _mutex[DBNum].ReleaseMutex();
            }
        }

        public Dictionary<string, string> GetAllStrings(int DBNum)
        {
            try
            {
                _mutex[DBNum].WaitOne();
                var map = new Dictionary<string, string>();

                string line;
                var reader = new StreamReader(db[DBNum]);
                while ((line = reader.ReadLine()) != null)
                {
                    var success = TryParseString(line, out var dataKey, out var dataValue);
                    if (!success) continue;

                    map[dataKey] = dataValue;
                }

                return map;
            }
            finally
            {
                _mutex[DBNum].ReleaseMutex();
            }
        }

        public void DestroyStorage()
        {
            for (var i = 0; i < CountOfDataBases; i++)
            {
                db[i].Flush();
                db[i].Close();
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
            if (delimiter <= 0) return false;

            if (!ValidateQuotes(line.Substring(0, delimiter + 1), out key) ||
                !ValidateQuotes(line.Substring(delimiter + 2), out value))
                return false;


            return true;
        }

        private bool InternalTryDelete(int DBNum, string key)
        {
            var reader = new StreamReader(db[DBNum]);

            var isDeleted = false;
            using (var tmpWriter = new StreamWriter(_basePathToFile + DBNum + "tmp"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string dataKey;
                    var success = TryParseString(line, out dataKey, out _);

                    if (!success || dataKey.Equals(key))
                    {
                        if (dataKey == key) isDeleted = true;
                        continue;
                    }

                    tmpWriter.WriteLine(line);
                }

                db[DBNum].Close();
                File.Delete(_basePathToFile + DBNum);
                tmpWriter.Close();
                File.Move(_basePathToFile + DBNum + "tmp", _basePathToFile + DBNum);
            }

            OpenFile(DBNum);

            return isDeleted;
        }

        private void OpenFile(int DBNum)
        {
            db[DBNum] = File.Open(_basePathToFile + DBNum, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }
    }
}