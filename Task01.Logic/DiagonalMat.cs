using System;

namespace Task01.Logic
{
    public class DiagonalMat<T>:SquareMat<T>,ICloneable
    {
        public DiagonalMat(int size) : base(size)
        {
        }

        public DiagonalMat(T[,] data): base(data)
        {
            if (!IsDiagonalMat) throw new ArgumentException("input two dimension array must be a diagonal matrix");
        }

        public override T this[int i, int j]
        {
            get
            {
                return base[i, j];
            }
            set
            {
                if(i!=j) throw new ArgumentException();
                base[i, j] = value;
            }
        }

        public DiagonalMat<T> Clone()
        {
            return new DiagonalMat<T>(data);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
