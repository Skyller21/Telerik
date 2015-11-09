namespace HashSetImplementation
{
    using _04.HashTableImplementation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashedSet<T> : IEnumerable<T>
    {
        private readonly HashTable<int, T> elements;

        public HashedSet(HashTable<int, T> foundation)
        {
            this.elements = foundation;
        }

        public HashedSet()
            : this(new HashTable<int, T>())
        {
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }


        public void Add(T item)
        {
            if (!this.elements.Contains(new KeyValuePair<int, T>(item.GetHashCode(), item)))
            {
                this.elements.Add(item.GetHashCode(), item);
            }
        }

        public void Clear()
        {
            this.elements.Clear();
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            var iterator = this.elements.GetEnumerator();

            while (arrayIndex < array.Length && iterator.MoveNext())
            {
                array[arrayIndex] = iterator.Current.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var set = new HashSet<T>();
            foreach (var item in this.elements)
            {
                if (set.Add(item.Value))
                {
                    yield return item.Value;
                }
            }
        }

        public void Remove(T item)
        {
            this.elements.Remove(item.GetHashCode());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public HashedSet<T> UnionWith(params ICollection<T>[] sets)
        {
            var result = new HashedSet<T>();

            foreach (var item in this)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            foreach (var set in sets)
            {
                foreach (var item in set)
                {
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public HashedSet<T> IntersectWith(params ICollection<T>[] sets)
        {
            var result = new HashedSet<T>();

            foreach (var set in sets)
            {
                foreach (var item in set)
                {
                    if (this.Contains(item) && sets.All(s => s.Contains(item)))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}