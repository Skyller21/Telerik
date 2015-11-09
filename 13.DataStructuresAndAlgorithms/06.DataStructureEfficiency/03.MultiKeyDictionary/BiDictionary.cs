using System;
using System.Collections.Generic;

namespace _03.MultiKeyDictionary
{
    using System.Linq;

    class BiDictionary<TKey1, TKey2, TValue> : Dictionary<TKey1, Dictionary<TKey2, TValue>>
    {
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get
            {
                if (!ContainsKey(key1) || !this[key1].ContainsKey(key2))
                    throw new ArgumentOutOfRangeException();
                return base[key1][key2];
            }
            set
            {
                if (!ContainsKey(key1))
                    this[key1] = new Dictionary<TKey2, TValue>();
                this[key1][key2] = value;
            }
        }

        // It is working like a set. If you already have a [key1][key2] it returns false, else returns true.
        public bool Add(TKey1 key1, TKey2 key2, TValue value)
        {
            if (!ContainsKey(key1))
            {
                this[key1] = new Dictionary<TKey2, TValue>();
            }

            if (!this[key1].ContainsKey(key2))
            {
                this[key1][key2] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
            return base.ContainsKey(key1) && this[key1].ContainsKey(key2);
        }

        public new IEnumerable<TValue> Values
        {
            get
            {
                return from baseDict in base.Values
                       from baseKey in baseDict.Keys
                       select baseDict[baseKey];
            }
        }
    }
}
