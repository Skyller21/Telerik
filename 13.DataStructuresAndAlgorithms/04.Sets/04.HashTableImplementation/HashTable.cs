using System.Collections.Generic;

namespace _04.HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const double ResizeFactor = 0.75;


        private LinkedList<KeyValuePair<K, V>>[] elements;
        private int currentCount;
        private ICollection<K> keys;
        private int capacity;


        public HashTable()
        {
            this.Elements = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            this.CurrentCount = 0;
            this.Keys = new HashSet<K>();
            this.Capacity = InitialCapacity;
        }


        private LinkedList<KeyValuePair<K, V>>[] Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        private int CurrentCount
        {
            get { return this.currentCount; }
            set { this.currentCount = value; }
        }

        public ICollection<K> Keys
        {
            get { return this.keys; }
            private set { this.keys = value; }
        }

        private int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.CurrentCount; }
        }

        public V this[K key]
        {
            get { return Find(key); }

            set { this.Add(key, value); }
        }

        // This should return bool maybe :)
        public V Find(K key)
        {
            V value = default(V);

            var index = this.HashKey(key, this.Elements);

            if (this.Elements[index] != null)
            {
                foreach (var kvPair in this.Elements[index])
                {
                    if (key.Equals(kvPair.Key))
                    {
                        value = kvPair.Value;
                        return value;
                    }
                }
            }
            
            return value;
        }


        public void Add(K key, V value)
        {
            if (this.CurrentCount + 1 >= ResizeFactor * this.Capacity)
            {
                Resize();
            }

            this.Keys.Add(key);

            var pairToAdd = new KeyValuePair<K, V>(key, value);
            var index = this.HashKey(key, this.Elements);



            if (this.Elements[index] == null)
            {
                this.Elements[index] = new LinkedList<KeyValuePair<K, V>>();
                this.Elements[index].AddLast(pairToAdd);

                
            }
            else
            {
                this.Elements[index].AddLast(pairToAdd);
            }

            this.CurrentCount++;
        }

        public void Remove(K key)
        {
            var index = this.HashKey(key, this.Elements);
            V valueToRemove = default(V);

            valueToRemove = this.Find(key);

            if (!valueToRemove.Equals(default(V)))
            {
                var pairToRemove = this.Elements[index].FirstOrDefault(x => x.Key.Equals(key));
                this.Elements[index].Remove(pairToRemove);
                this.CurrentCount--;
                this.keys.Remove(key);
            }
        }

        private int HashKey(K key, LinkedList<KeyValuePair<K, V>>[] elements)
        {
            return Math.Abs(key.GetHashCode() % elements.Length);
        }

        private void Resize()
        {
            this.Capacity *= 2;
            var newElements = new LinkedList<KeyValuePair<K, V>>[this.Capacity];

            foreach (var key in this.Keys)
            {
                var newIndex = this.HashKey(key, newElements);
                var oldIndex = this.HashKey(key, this.Elements);
                newElements[newIndex] = elements[oldIndex];
            }

            this.elements = newElements;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.elements)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Clear()
        {
            this.Elements = new LinkedList<KeyValuePair<K, V>>[this.Elements.Length];
            this.keys.Clear();
            this.CurrentCount = 0;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var list in this.Elements)
            {
                if (list != null)
                {
                    foreach (var kvPair in list)
                    {
                        result.Append(kvPair);
                        result.Append(", ");
                    }
                    result.AppendLine();
                }
            }

            return result.ToString();
        }

    }
}

