using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task01.Logic.Rafactoring
{
    /// <summary>
    /// class of abstract square matrix
    /// </summary>
    public abstract class AbstractSquareMatrix<T>:IEnumerable<T>
    {
        /// <summary>
        /// all data will
        /// </summary>
        protected T[] data;

        public int Size { get; protected set; }

        public event EventHandler<ElementChangeEventArgs<T>> Change = delegate { };

        public T this[int i, int j]
        {
            get
            {
                ValidateGet(i,j);
                return Get(i,j);
            }
            set
            {
                ValidateSet(i,j);
                OnChange(new ElementChangeEventArgs<T>(this[i, j], value, i, j));
                Set(i,j,value);               
            }
        }

        private void ValidateGet(int i, int j)
        {
            if(i >= Size || j >= Size || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
        }

        protected virtual void ValidateSet(int i, int j)
        {
            if (i >= Size || j >= Size || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
        }

        protected abstract T Get(int i, int j);

        protected abstract void Set(int i, int j, T value);

        protected void OnChange(ElementChangeEventArgs<T> eventArgs)
        {
            EventHandler<ElementChangeEventArgs<T>> temp = Volatile.Read(ref Change);
            temp?.Invoke(this, eventArgs);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
