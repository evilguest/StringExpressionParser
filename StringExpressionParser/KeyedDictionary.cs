using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExpressionParser
{
    public class KeyedDictionary<K, T> : IReadOnlyDictionary<K, T>
        where K: notnull
    {
        public KeyedDictionary(Func<T, K> keyExtractor, string elementType)
        {
            _keyExtractor = keyExtractor ?? throw new ArgumentNullException(nameof(keyExtractor));
            _dictionary = new(elementType);
        }

        private readonly Func<T, K> _keyExtractor;


        #region IReadOnlyDictionary<K, T>
        private readonly ExpressionDictionary<K, T> _dictionary;

        public T this[K key] =>  _dictionary[key];

        public IEnumerable<K> Keys => _dictionary.Keys;

        public IEnumerable<T> Values => _dictionary.Values;

        public int Count => ((IReadOnlyCollection<KeyValuePair<K, T>>)_dictionary).Count;

        public bool ContainsKey(K key) => _dictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator() => _dictionary.GetEnumerator();

        public bool TryGetValue(K key, [MaybeNullWhen(false)] out T value) => _dictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_dictionary).GetEnumerator();
        #endregion
        public void Add(T value) => _dictionary.Add(_keyExtractor(value), value);

        public void Add(params T[] values)
        {
            foreach (var value in values)
                Add(value);
        }
    }
}
