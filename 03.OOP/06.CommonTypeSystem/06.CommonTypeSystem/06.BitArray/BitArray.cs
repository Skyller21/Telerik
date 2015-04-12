using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BitArray
{
    internal class BitArray : IEnumerable<int>, IComparable
    {
        private ulong num;

        public BitArray(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get { return num; }
            set { num = value; }
        }

        public int this[int pos]
        {
            get
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                return ((int) (this.Number >> pos) & 1);
            }
            set
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                if (value!= 0 && value != 1)
                {
                    throw new ArgumentException("Invalid bit value.");
                }

                if (((int) (this.Number >> pos) & 1) != value)
                {
                    this.Number ^= (1ul << pos);
                }
            }
        }

        public static bool operator ==(BitArray arr1, BitArray arr2)
        {
            return (arr1.Equals(arr2));
        }

        public static bool operator !=(BitArray arr1, BitArray arr2)
        {
            return !(arr1.Equals(arr2));
        }



        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int pos = 0; pos < 64; pos++)
            {
                result.Insert(0, ((this.Number >> pos) & 1));
            }

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Number.Equals((obj as BitArray).Number);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int pos = 0; pos < 64; pos++)
            {
                yield return this[pos];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(object obj)
        {
            return this.Number.CompareTo((obj as BitArray).Number);
        }

        public static ulong ToNumber(BitArray arr)
        {
            ulong num = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                num += (ulong)Math.Pow(2*arr[i], i);
            }

            return num;
        }
    }
}
