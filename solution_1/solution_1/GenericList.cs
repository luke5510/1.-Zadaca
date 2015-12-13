using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericList
{
    class GenericList<X> : IGenericList<X>
    {
        private const int IN_SIZE = 4;
        private X[] internalStorage;
        private int tailIndex = 0;
        private int size;

        public GenericList()
        {
            internalStorage = new X[IN_SIZE];
            size = IN_SIZE;
        }

        public GenericList(int initialSize)
        {
            internalStorage = new X[initialSize];
            size = initialSize;
        }


        public void Add(X item)
        {
            if (tailIndex == size - 1)
            {
                X[] auxiliaryArray = new X[2 * size];
                for (int i = 0; i < size; i++)
                {
                    auxiliaryArray[i] = this.internalStorage[i];
                }
                size = 2 * size;
                internalStorage = auxiliaryArray;
            }

            else
            {
                internalStorage[++tailIndex] = item;
            }
        }

        public void Clear()
        {
            internalStorage = null;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i <= tailIndex; i++)
            {
                if (internalStorage[i].Equals(item)) return true;
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index <= tailIndex && index >= 0) return internalStorage[index];
            else
            {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= tailIndex; i++)
            {
                if (internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > tailIndex) return false;
            else if (index == tailIndex) tailIndex--;
            else
            {
                for (int i = index; i < tailIndex - 1; i++)
                {
                    internalStorage[i] = internalStorage[i + 1];
                }
            }
            return true;
        }

        public int Count
        {
            get
            {
                return tailIndex + 1;
            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
