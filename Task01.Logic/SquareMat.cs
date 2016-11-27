using System;

namespace Task01.Logic
{
    public class SquareMat<T> : Matrix<T>,ICloneable
    {
        public int size;
        public SquareMat(int size):base(size,size)
        {
            this.size = size;
        }

        public SquareMat(T[,] data) : base(data)
        {
            if (data.GetLength(0) != data.GetLength(1))
                throw new ArgumentException("input two dimansion array must be square", nameof(data));
            size = data.GetLength(0);
        }

        public bool IsDiagonalMat
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i != j && !data[i, j].Equals(default(T))) return false;
                    }
                }
                return true;
            }
        }

        public bool IsSymMat
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = i; j < size; j++)
                    {
                        if (!data[i, j].Equals(data[j, i])) return false;
                    }
                }
                return true;
            }
        }

        public SquareMat<T> Clone()
        {
            return new SquareMat<T>(data);
        }

        object ICloneable.Clone()
        {
           return Clone();
        }
    }
}
