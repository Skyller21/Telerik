using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FindWordsInText
{
    public abstract class TrieNodeBase<TValue>
    {
        protected abstract int KeyLength { get; }

        protected abstract IEnumerable<TValue> Values();

        protected abstract IEnumerable<TrieNodeBase<TValue>> Children();

        public void Add(string key, int position, TValue value, bool isCaseSensitive)
        {
            if (!isCaseSensitive)
            {
                key = key.ToLower();
            }

            if (key == null) throw new ArgumentNullException("key");
            if (EndOfString(position, key))
            {
                AddValue(value);
                return;
            }

            TrieNodeBase<TValue> child = GetOrCreateChild(key[position]);
            child.Add(key, position + 1, value, isCaseSensitive);
        }

        protected abstract void AddValue(TValue value);

        protected abstract TrieNodeBase<TValue> GetOrCreateChild(char key);

        protected virtual IEnumerable<TValue> Retrieve(string query, int position, bool isCaseSensitive)
        {
            if (!isCaseSensitive)
            {
                return
                    EndOfString(position, query.ToLower())
                        ? ValuesDeep()
                        : SearchDeep(query, position, false);
            }
            else
            {
                return
                    EndOfString(position, query)
                        ? ValuesDeep()
                        : SearchDeep(query, position, true);
            }
        }

        protected virtual IEnumerable<TValue> SearchDeep(string query, int position, bool isCaseSensitive)
        {

            if (!isCaseSensitive)
            {
                TrieNodeBase<TValue> nextNode = GetChildOrNull(query.ToLower(), position);
                return nextNode != null
                    ? nextNode.Retrieve(query.ToLower(), position + nextNode.KeyLength, isCaseSensitive)
                    : Enumerable.Empty<TValue>();
            }
            else
            {
                TrieNodeBase<TValue> nextNode = GetChildOrNull(query, position);
                return nextNode != null
                    ? nextNode.Retrieve(query, position + nextNode.KeyLength, isCaseSensitive)
                    : Enumerable.Empty<TValue>();
            }
        }

        protected abstract TrieNodeBase<TValue> GetChildOrNull(string query, int position);

        private static bool EndOfString(int position, string text)
        {
            return position >= text.Length;
        }

        private IEnumerable<TValue> ValuesDeep()
        {
            return
                Subtree()
                    .SelectMany(node => node.Values());
        }

        protected IEnumerable<TrieNodeBase<TValue>> Subtree()
        {
            return
                Enumerable.Repeat(this, 1)
                    .Concat(this.Children().SelectMany(child => child.Subtree()));
        }
    }
}
