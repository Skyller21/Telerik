using System;
using System.Collections.Generic;

namespace _01.PriorityQueue
{
    public class BinaryHeap<T>
    {
        protected T[] data;

        protected int size = 0;

        protected Comparison<T> comparison;

        public BinaryHeap(int capacity = 4, Comparison<T> comparison = null)
        {
            this.data = new T[capacity];
            this.comparison = comparison;
            if (this.comparison == null)
            {
                this.comparison = Comparer<T>.Default.Compare;
            }
        }

        public int Size
        {
            get { return this.size; }
        }

        ///
        /// Add an item to the heap
        ///
        public void Insert(T item)
        {
            if (this.size == this.data.Length)
            {
                Resize();
            }
            this.data[this.size] = item;
            HeapifyUp(this.size);
            this.size++;
        }

        ///
        /// Get the item of the root
        ///
        public T Peak()
        {
            return this.data[0];
        }

        ///
        /// Extract the item of the root
        ///
        public T Pop()
        {
            T item = this.data[0];
            this.size--;
            this.data[0] = this.data[this.size];
            HeapifyDown(0);
            return item;
        }

        private void Resize()
        {
            T[] resizedData = new T[this.data.Length * 2];
            Array.Copy(this.data, 0, resizedData, 0, this.data.Length);
            this.data = resizedData;
        }

        private void HeapifyUp(int childIdx)
        {
            if (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (this.comparison.Invoke(this.data[childIdx], this.data[parentIdx]) > 0)
                {
                    // swap parent and child
                    T t = this.data[parentIdx];
                    this.data[parentIdx] = this.data[childIdx];
                    this.data[childIdx] = t;
                    HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            int leftChildIdx = 2 * parentIdx + 1;
            int rightChildIdx = leftChildIdx + 1;
            int largestChildIdx = parentIdx;
            if (leftChildIdx < this.size && this.comparison.Invoke(this.data[leftChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = leftChildIdx;
            }
            if (rightChildIdx < this.size && this.comparison.Invoke(this.data[rightChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = rightChildIdx;
            }
            if (largestChildIdx != parentIdx)
            {
                T t = this.data[parentIdx];
                this.data[parentIdx] = this.data[largestChildIdx];
                this.data[largestChildIdx] = t;
                HeapifyDown(largestChildIdx);
            }
        }
    }
}