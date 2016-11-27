using System;

namespace Task01.Logic
{
    public class SymmetricalMat<T>:SquareMat<T>,ICloneable
    {
        public SymmetricalMat(int size):base(size)
        {
        }

        public SymmetricalMat(T[,] data) : base(data)
        {
            if (!IsSymMat) throw new ArgumentException("input two dimension array must be symmetrical matrix",nameof(data));
        }

        public override T this[int i, int j]
        {
            get { return base[i, j]; }
            set
            {
                if(i!=j) throw new ArgumentException();
                base[i, j] = value;
            }
        }

        public SymmetricalMat<T> Clone()
        {
            return new SymmetricalMat<T>(data);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

    }
}
