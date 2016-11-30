using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Logic.Rafactoring
{
    public class SquareMatrix<T>:AbstractSquareMatrix<T>
    {
        public SquareMatrix(int size)
        {
            Size = size;
            data = new T[size*size];
        }

        public SquareMatrix(T[,] data):this(data.GetLength(0))
        {
            if (data.GetLength(0) != data.GetLength(1)) throw new ArgumentException();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    this[i, j] = data[i, j];
                }
            }
        } 

        protected override T Get(int i, int j)
        {
            return data[i + j*Size];
        }

        protected override void Set(int i, int j, T value)
        {
            data[i + j*Size] = value;
        }
    }
}
