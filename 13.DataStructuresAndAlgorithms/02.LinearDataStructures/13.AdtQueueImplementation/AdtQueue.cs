namespace _13.AdtQueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AdtQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> list;


        public AdtQueue()
        {
            this.CurrentCount = 0;
            this.list = new LinkedList<T>();
        }

        private int CurrentCount { get; set; }

        public void Enqueue(T value)
        {
            if (value == null)
            {
                // notify the user somhow :)
                return;
            }

            if (this.CurrentCount == 0)
            {
                this.list.AddFirst(value);
            }
            else
            {
                this.list.AddLast(value);
            }

            this.CurrentCount++;
        }

        public T Dequeue()
        {
            if (this.CurrentCount == 0)
            {
                // notify the user somhow :) Not the best way but...
                throw new ArgumentNullException();
            }

            T removed = this.list.First.Value;
            this.list.RemoveFirst();

            this.CurrentCount--;
            return removed;
        }


        public T Peek()
        {
            if (this.CurrentCount == 0)
            {
                // notify the user somhow :) Not the best way but...
                throw new ArgumentNullException();
            }

            return this.list.First.Value;
        }

        public int Count()
        {
            return this.CurrentCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = list.First;
            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
