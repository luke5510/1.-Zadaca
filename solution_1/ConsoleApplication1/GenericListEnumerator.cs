using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericList
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private IGenericList<T> collection;
        private int currentIndex=0;
        private int sizeOf;
        public GenericListEnumerator(IGenericList<T> collection)
        {
            this.collection = collection;
            sizeOf = this.collection.Count;
        }

        public bool MoveNext()
        {
            return currentIndex < sizeOf;
        }
        public T Current
        {
            get
            {
                return collection.GetElement(currentIndex++);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose()
        {
        }
        public void Reset()
        {
        }
    }
}
