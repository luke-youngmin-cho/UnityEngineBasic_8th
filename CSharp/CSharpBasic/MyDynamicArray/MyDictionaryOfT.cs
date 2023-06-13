using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class MyDictionary<TKey, TValue>
    {
        private struct ValuePair
        {
            public bool isSet;
            public TValue value;
        }

        private const int DEFAULT_SIZE = 100;
        private ValuePair[] _values = new ValuePair[DEFAULT_SIZE];

        public TValue this[TKey key]
        {
            get
            {
                int tmpHash = Hash(key);
                if (_values[tmpHash].isSet)
                {
                    return _values[tmpHash].value;
                }
                else
                {
                    throw new Exception($"[MyDictionary] : has not key {key}");
                }
            }
            set
            {
                int tmpHash = Hash(key);
                if (_values[tmpHash].isSet)
                {
                    _values[tmpHash].value = value;
                }
                else
                {
                    throw new Exception($"[MyDictionary] : has not key {key}");
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            int tmpHash = Hash(key);

            if (_values[tmpHash].isSet)
                throw new Exception($"[MyDictionary] : key {key} is already exist");

            _values[tmpHash].value = value;
            _values[tmpHash].isSet = true;
        }

        public void Remove(TKey key, TValue value)
        {
            int tmpHash = Hash(key);

            if (_values[tmpHash].isSet == false)
                throw new Exception($"[MyDictionary] : key {key} doesnt exist");

            _values[tmpHash].value = default(TValue);
            _values[tmpHash].isSet = false;
        }

        public bool Contains(TKey key)
        {
            return _values[Hash(key)].isSet;
        }

        // out 키워드 
        // 파라미터 앞에 붙어서, 해당 함수가 반환될때 상위 스택의 함수의 변수로 파라미터의 값을 반환. 
        // 보통 2가지 이상의 값을 반환받아야 할 때 사용.
        public bool TryGetValue(TKey key, out TValue value)
        {
            int tmpHash = Hash(key);

            if (_values[tmpHash].isSet)
            {
                value = _values[tmpHash].value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }


        private int Hash(TKey key)
        {
            string tmpString = key.ToString();
            int tmpHash = 0;

            for (int i = 0; i < tmpString.Length; i++)
            {
                tmpHash += tmpString[i];
            }
            tmpHash %= DEFAULT_SIZE;
            return tmpHash;
        }
    }
}
