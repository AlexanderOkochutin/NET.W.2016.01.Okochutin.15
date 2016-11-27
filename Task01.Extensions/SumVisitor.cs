using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Logic;

namespace Task01.Extensions
{
    public class SumVisitor<T> : IMatrixVsitor<T>
    {
        public dynamic Sum { get; private set; }
        private readonly dynamic otherMat;

        public SumVisitor(SquareMat<T> secondMat)
        {
           if(secondMat == null) throw  new ArgumentNullException(nameof(secondMat));
           otherMat = secondMat;
        }

        public void Visit(SquareMat<T> firstMat)
        {
            if(firstMat==null) throw new ArgumentNullException(nameof(firstMat));
            if(firstMat.size!=otherMat.size) throw new ArgumentException("both matrix must be the same size");
            SquareMat<T> result = new SquareMat<T>(firstMat.size);
            for (int i = 0; i < firstMat.size; i++)
            {
                for (int j = 0; j < firstMat.size; j++)
                {
                    result[i, j] = firstMat[i, j] + otherMat[i, j];
                }
            }
            Sum = result;
        }
    }
}
