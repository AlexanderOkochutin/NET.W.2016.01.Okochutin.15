using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Logic;

namespace Task01.Extensions
{
    public static class Extensions
    { 
        public static SquareMat<T> Sum<T>(SquareMat<T> firstMat, SquareMat<T> secondMat)
        {
            if(firstMat==null || secondMat == null) throw new ArgumentNullException();
            var visitor = new SumVisitor<T>(secondMat);
            firstMat.Accept(visitor);
            return visitor.Sum;
        } 
    }
}
