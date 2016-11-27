using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task01.Logic
{
    public abstract class Matrix<T>: IEnumerable<T>
    {
        /// <summary>
        /// data storage rectangle array
        /// </summary>
        protected T[,] data;

        /// <summary>
        /// element chnage event
        /// </summary>
        public event EventHandler<ElementChangeEventArgs<T>> Change = delegate { };

        /// <summary>
        /// constructor based on array
        /// </summary>
        protected Matrix(T[,] data)
        {
            if(data == null) throw new ArgumentNullException(nameof(data));
            this.data = data;
        }

        /// <summary>
        /// constructor based on rows and cols
        /// </summary>
        protected Matrix(int row, int col)
        {
            if(row <1 || col <1) throw new ArgumentOutOfRangeException();
            data = new T[row,col];
        }

        /// <summary>
        /// virtual indexator
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">col</param>
        /// <returns>element on this position</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < data.GetLength(0) && j < data.GetLength(1))
                    return data[i, j];
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < data.GetLength(0) && j < data.GetLength(1))
                {
                    OnChange(new ElementChangeEventArgs<T>(data[i, j], value, i, j));
                    data[i, j] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }

        /// <summary>
        /// acceptor of external visitor
        /// </summary>
        /// <param name="visitor">classs which implements IMatrixVisitor</param>
        public void Accept(IMatrixVsitor<T> visitor)
        {
           visitor.Visit((dynamic)this);
        }

        protected virtual void OnChange(ElementChangeEventArgs<T> eventArgs)
        {
            EventHandler<ElementChangeEventArgs<T>> temp = Volatile.Read(ref Change);
            temp?.Invoke(this, eventArgs);
        }

        public bool Equals(Matrix<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (!data[i, j].Equals(other[i, j])) return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((T)obj);
        }

        public override int GetHashCode()
        {
            return this.Aggregate(0, (current, item) => 31*current + item.GetHashCode()*17);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    yield return data[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
