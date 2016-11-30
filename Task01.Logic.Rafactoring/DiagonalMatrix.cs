using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Logic.Rafactoring
{
    public class DiagonalMatrix<T>:AbstractSquareMatrix<T>
    {
        public DiagonalMatrix(int size)
        {
            Size = size;
            data = new T[size];
        }

        public DiagonalMatrix(T[,] data) : this(data.GetLength(0))
        {
            if (data.GetLength(0) != data.GetLength(1)) throw new ArgumentException();
            if (!IsDiagonal(data)) throw new ArgumentException(); 
            for (int i = 0; i < Size; i++)
            {
                this[i, i] = data[i, i];
            }
        } 

        protected override T Get(int i, int j)
        {
            if (i == j)
            {
                return data[i];
            }
            else
            {
                return default(T);
            }
        }

        protected override void Set(int i, int j, T value)
        {
            if (i == j)
            {
                data[i] = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private bool IsDiagonal(T[,] data)
        {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (i != j && !data[i, j].Equals(default(T))) return false;
                    }
                }
                return true;
        }

        protected override void ValidateSet(int i, int j)
        {
            if(i!=j) throw new ArgumentException();
        }
    }
}
