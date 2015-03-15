namespace Generics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class GenericList<T> where T : IComparable,IComparable<T>, new()
    {
        private const int InitialCapacity = 1;
        private int count;
        private int capacity;

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("The capacity of the list cannot be less than one!!!");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }
        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The count of the elements cannot be less than zero!!!");
                }
                else
                {
                    this.count = value;
                }
            }
        }
        public T[] List { get; set; }


        public GenericList(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.List = new T[this.Capacity];
        }

        public void DoubleArray()
        {
            if (this.Count >= this.Capacity)
            {
                this.Capacity *= 2;
                T[] arr = (T[])List.Clone();
                Array.Resize(ref arr, this.Capacity);
                this.List = (T[])arr.Clone();

            }
        }

        public void CutArrayAtHalf()
        {
            if (this.Count <= this.Capacity / 2)
            {
                this.Capacity /= 2;
            }
        }

        public void Add(T element)
        {
            this.Count++;

            this.List[this.Count - 1] = element;

            DoubleArray();

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count - 1)
                throw new ArgumentOutOfRangeException();

            for (int i = index + 1; i < this.Count; i++)
            {
                this.List[i - 1] = this.List[i];
            }
            this.Count--;
            CutArrayAtHalf();
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.Count - 1)
                throw new ArgumentOutOfRangeException();

            this.Count++;
            for (int i = this.Count - 1; i > index; i--)
            {
                this.List[i] = this.List[i - 1];
            }
            this.List[index] = element;

            DoubleArray();
        }

        public void Clear()
        {
            this.Capacity = InitialCapacity;
            this.Count = 0;
            this.List = new T[InitialCapacity];
        }


        public int IndexOf(T element)
        {
            return Array.IndexOf(this.List, element);
        }
        public T Max()
        {
            T max = default(T);
            
            if (this.Count > 0)
            {
                max = this.List[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.List[i].CompareTo(max)>0)
                    {
                        max = this.List[i];   
                    }
                }
            }

            return max;
        }

        public T Min()
        {
            T min = default(T);

            if (this.Count > 0)
            {
                min = this.List[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.List[i].CompareTo(min) < 0)
                    {
                        min = this.List[i];
                    }
                }
            }

            return min;
        }
        public override string ToString()
        {
            string[] temp = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                temp[i] = this.List[i].ToString();
            }
            return String.Join(", ", temp);
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                    throw new ArgumentOutOfRangeException();

                return this.List[index];

            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                    throw new ArgumentOutOfRangeException();

                this.List[index] = value;

            }
        }
    }
}
