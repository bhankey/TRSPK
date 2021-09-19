namespace CalorieContent.lib.KeyValueStorage
{
    public interface IStorage
    {
        public bool TryGetString(string key, out string result);
        public void SetString(string key, string value);
        public bool TryDelete(string key);
    }
}