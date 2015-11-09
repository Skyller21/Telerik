namespace _12.AdtStackImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class AdtStack<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] array;

        public AdtStack()
        {
            this.CurrentCount = 0;
            this.Capacity = 4;
            this.array = new T[this.Capacity];
        }

        public int Capacity { get; private set; }

        private int CurrentCount { get; set; }

        public int Count()
        {
            return this.CurrentCount;
        }

        public void Push(T value)
        {
            if (value == null)
            {
                // notify the user somehow again :D
                return;
            }

            if (this.CurrentCount + 1 >= this.Capacity)
            {
                this.array = ResizeArray();
            }

            this.array[this.CurrentCount] = value;
            this.CurrentCount++;

        }


        public T Pop()
        {
           var removed = default(T);

            removed = this.array[this.CurrentCount - 1];
            this.array[this.CurrentCount - 1] = default(T);

            this.CurrentCount--;
            return removed;
        }


        public T Peek()
        {
            return this.array[this.CurrentCount - 1];
        }

        private T[] ResizeArray()
        {
            this.Capacity *= 2;
            var tempArray = new T[this.Capacity];

            for (int i = 0; i < this.array.Length; i++)
            {
                tempArray[i] = this.array[i];
            }

            return tempArray;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.CurrentCount; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
