using System.Collections.Generic;

namespace CalorieContent.lib.KeyValueStorage
{
    public interface IStorage
    {
        public bool TryGetString(int DBNum, string key, out string result);
        public void SetString(int DBNum, string key, string value);
        public bool TryDelete(int DBNum, string key);

        public Dictionary<string, string> GetAllStrings(int DBNum);
    }
}