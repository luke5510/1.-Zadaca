
namespace genericList
{
    class IntegerList : IIntegerList
    {
        private const int IN_SIZE = 4;
        private int[] internalStorage;
        private int tailIndex = -1;
        private int size;

        public IntegerList()
        {
            internalStorage = new int[IN_SIZE];
            size = IN_SIZE;
        }

        public IntegerList(int initialSize)
        {
            internalStorage = new int[initialSize];
            size = initialSize;
        }
        

        public void Add(int item)
        {
            if (tailIndex == size - 1)
            {
                int[] auxiliaryArray = new int[2 * size];
                for (int i=0; i<size; i++)
                {
                    auxiliaryArray[i] = this.internalStorage[i];
                }
                size = 2 * size;
                internalStorage = auxiliaryArray;

            }
            
            internalStorage[++tailIndex] = item;
           
        }

        public void Clear()
        {
            internalStorage = new int[IN_SIZE];
            size = IN_SIZE;
            tailIndex = -1;
        }

        public bool Contains(int item)
        {
            for (int i=0; i<=tailIndex;i++)
            {
                if (internalStorage[i] == item) return true;
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index <= tailIndex && index>=0) return internalStorage[index];
            else
            {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i<=tailIndex; i++)
            {
                if (internalStorage[i] == item) return i;
            }
            return -1;
        }

        public bool Remove(int item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > tailIndex) return false;
            else if (index == tailIndex) tailIndex--;
            else
            {
                for (int i = index; i < tailIndex ; i++)
                {
                    internalStorage[i] = internalStorage[i + 1];
                }
                tailIndex--;
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
        
        
    }
}
