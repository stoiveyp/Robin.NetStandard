namespace Robin.NetStandard
{
    internal static class DictionaryExtensions
    {
        internal static void AddIfNotEmpty(this Dictionary<string, string> dict, string key, string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                dict.Add(key,value);
            }
        }
    }
}
