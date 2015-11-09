namespace _01.PriorityQueue
{
    using System;

    public class PriorityQueue<T>
    {
        private BinaryHeap<T> data;


        public PriorityQueue()
        {
            this.data = new BinaryHeap<T>();
        }

        public PriorityQueue(Comparison<T> comparison)
        {
            this.data = new BinaryHeap<T>(4, comparison);
        }

        public int Count
        {
            get { return this.data.Size; }
        }

        public void Enqueue(T item)
        {
            this.data.Insert(item);
        }

        public T Dequeue()
        {
            return this.data.Pop();
        }

        public T Peek()
        {
            return this.data.Peak();
        }
    }
}
