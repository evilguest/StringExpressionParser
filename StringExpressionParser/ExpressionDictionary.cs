using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExpressionParser
{
    public class ExpressionDictionary<K, T> : Dictionary<K, T>
        where K : notnull
    {
        private readonly string _elementType;

        public ExpressionDictionary(string elementType) =>
            _elementType = !string.IsNullOrWhiteSpace(elementType)
            ? elementType
            : throw new ArgumentException($"'{nameof(elementType)}' cannot be null or whitespace.", nameof(elementType));

        public new T this[K key]
        {
            set => base[key] = ContainsKey(key) ? throw new ArgumentException($"{_elementType} '{key}' is already defined as {base[key]}") : value;
            get => TryGetValue(key, out var value) ? value : throw new ArgumentException($"{_elementType} '{key}' is not defined");
        }
    }
}
