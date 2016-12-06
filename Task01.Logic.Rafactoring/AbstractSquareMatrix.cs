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

        /// <summary>
        /// numbers of row's or column's
        /// </summary>
        public int Size { get; protected set; }

        /// <summary>
        /// eventhandler for event on element change
        /// </summary>
        public event EventHandler<ElementChangeEventArgs<T>> Change = delegate { };

        /// <summary>
        /// indexator for our matrix
        /// </summary>
        /// <param name="i">number of row</param>
        /// <param name="j">number of column</param>
        /// <returns>getter return element on this position</returns>
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

        /// <summary>
        /// check that index not going out of range
        /// </summary>
        /// <param name="i">number of row</param>
        /// <param name="j">number of column</param>
        private void ValidateGet(int i, int j)
        {
            if(i >= Size || j >= Size || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// check set of element into matrix, for different matrix different setters
        /// </summary>
        /// <param name="i">number of row</param>
        /// <param name="j">number of column</param>
        protected virtual void ValidateSet(int i, int j)
        {
            if (i >= Size || j >= Size || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// getter for indexator
        /// </summary>
        protected abstract T Get(int i, int j);

        /// <summary>
        /// setter for indexator
        /// </summary>
        protected abstract void Set(int i, int j, T value);

        /// <summary>
        /// event, happens when we set a new element with help of indexator
        /// </summary>
        /// <param name="eventArgs"></param>
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
