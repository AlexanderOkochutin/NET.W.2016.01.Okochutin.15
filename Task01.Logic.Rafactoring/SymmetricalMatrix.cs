using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Logic.Rafactoring
{
    public class SymmetricalMatrix<T> : AbstractSquareMatrix<T>
    {
        public SymmetricalMatrix(int size)
        {
            Size = size;
            data = new T[(int) (Size + 1)*Size/2];
        }

        public SymmetricalMatrix(T[,] data) : this(data.GetLength(0))
        {
            if (data.GetLength(0) != data.GetLength(1)) throw new ArgumentException();
            if (!IsSymmetrical(data)) throw new ArgumentException();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0 ; j < Size; j++)
                {
                    if (j >= i) 
                        this.data[i + j + (2 * (Size - 1) - i - 1) * i / 2] = data[i, j];
                }
            }
        }

        protected override T Get(int i, int j)
        {
            if (i >= j)
            {
                return data[GetOneDimIndex(i,j)];
            }
            else
            {
                return data[GetOneDimIndex(j,i)];
            }
        }

        protected override void Set(int i, int j, T value)
        {
            if (i == j)
            {
                data[GetOneDimIndex(i,j)] = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private int GetOneDimIndex(int i, int j)
        {
            return i + j + (2 * (Size - 1) - i - 1) * i / 2;
        }

        protected override void ValidateSet(int i, int j)
        {
            if(i!=j) throw  new ArgumentException();
        }

        private bool IsSymmetrical(T[,] data)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Size; j++)
                {
                    if (!data[i, j].Equals(data[j, i])) return false;
                }
            }
            return true;
        }
    }
}
