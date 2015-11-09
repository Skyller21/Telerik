using System.Collections.Generic;

namespace _03.FindWordsInText
{
    public class Trie<TValue> : TrieNode<TValue>
    {
        private readonly bool isCaseSensitive;

        /// <summary>
        /// Creates case sensitive trie by default.
        /// </summary>
        public Trie() : this(true)
        {
        }

        /// <summary>
        /// If false the search is case insensitive.
        /// </summary>
        /// <param name="isCaseSensitive"></param>
        public Trie(bool isCaseSensitive)
        {
            this.isCaseSensitive = isCaseSensitive;
        }

        public IEnumerable<TValue> Retrieve(string query)
        {
            if (isCaseSensitive)
            {
                return Retrieve(query, 0, true);
            }
            else
            {
                return Retrieve(query, 0, false);

            }
        }

        public void Add(string key, TValue value)
        {
            if (this.isCaseSensitive)
            {
                Add(key, 0, value, true);
            }
            else
            {
                Add(key.ToLower(), 0, value, false);
            }
        }
    }
}
