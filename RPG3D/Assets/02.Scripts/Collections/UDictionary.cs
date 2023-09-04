using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Collections
{
    [Serializable]
    public class UDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        public TValue this[TKey key]
        {
            get => _dictionary [key];
            set => _dictionary[key] = value;
        }

        [SerializeField] private List<UKeyValuePair<TKey, TValue>> _list;
        private Dictionary<TKey, TValue> _dictionary;

        public UDictionary(IEnumerable<UKeyValuePair<TKey, TValue>> copy)
        {
            Initialize(copy);
        }

        public UDictionary()
        {
        }


        public void Initialize(IEnumerable<UKeyValuePair<TKey, TValue>> copy)
        {
            _list = new List<UKeyValuePair<TKey, TValue>>(copy);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            if (_list == null)
                return;

            _dictionary = new Dictionary<TKey, TValue>();
            foreach (var item in _list)
            {
                _dictionary.TryAdd(item.Key, item.Value);
            }
        }

        public void Add(TKey key, TValue value) => _dictionary.Add(key, value);
    }
}