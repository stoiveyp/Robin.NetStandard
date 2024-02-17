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

        internal static void AddIfNotEmpty<T>(this Dictionary<string, string> dict, string key, T? value) where T:struct
        {
            if (value.HasValue)
            {
                dict.Add(key, value.Value.ToString());
            }
        }
    }
}
