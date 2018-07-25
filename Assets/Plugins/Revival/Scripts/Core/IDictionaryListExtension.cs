using System.Collections.Generic;

namespace Revival
{
    public static class IDictionaryListExtension
    {
        public static void AddSafely<TKey, TValue>(
            this IDictionary<TKey, IList<TValue>> dictionary,
            TKey key,
            TValue value
        )
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary[key] = default(IList<TValue>);
            }

            if (dictionary[key] == default(IList<TValue>))
            {
                dictionary[key] = new List<TValue>();
            }

            dictionary[key].Add(value);
        }

        public static IList<TValue> GetSafely<TKey, TValue>(
            this IDictionary<TKey, IList<TValue>> dictionary,
            TKey key
        )
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : new List<TValue>();
        }

        public static TValue GetOrSet<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            System.Func<TValue> creator
        )
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];
            dictionary[key] = creator();
            return dictionary[key];
        }
    }
}