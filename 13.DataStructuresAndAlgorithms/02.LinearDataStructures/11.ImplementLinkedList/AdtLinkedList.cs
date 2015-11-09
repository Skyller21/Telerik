namespace _11.ImplementLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AdtLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        public ListItem<T> FirstElement { get; set; }

        private int CurrentCount { get; set; }

        public void Add(T element)
        {
            if (element == null)
            {
                // notify the user somehow
                return;
            }

            var newElement = new ListItem<T>(element);

            if (this.CurrentCount == 0)
            {
                this.FirstElement = newElement;
            }
            else
            {
                var currentElement = this.FirstElement;

                for (int i = 0; i < this.CurrentCount; i++)
                {
                    if (i == this.CurrentCount - 1)
                    {
                        currentElement.NextItem = newElement;
                    }

                    currentElement = currentElement.NextItem;
                }
            }

            this.CurrentCount++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.CurrentCount)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }


            T removed = default(T);

            if (index == 0)
            {
                removed = this.FirstElement.Value;
                this.FirstElement = this.FirstElement.NextItem;
            }
            else
            {
                var currentElement = this.FirstElement.NextItem;
                var previousElement = this.FirstElement;

                for (int i = 1; i < this.CurrentCount; i++)
                {
                    if (i == index)
                    {
                        removed = currentElement.Value;
                        var nextElement = currentElement.NextItem;
                        previousElement.NextItem = nextElement;
                        break;

                    }

                    previousElement = currentElement;
                    currentElement = currentElement.NextItem;
                }
            }

            this.CurrentCount--;

            return removed;
        }

        public int Count()
        {
            return this.CurrentCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.FirstElement;

            while (currentElement != null)
            {
                yield return currentElement.Value;

                currentElement = currentElement.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
