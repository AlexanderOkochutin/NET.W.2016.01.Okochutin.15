using System;
using System.Collections.Generic;

namespace Task02.Logic
{
    public class ComparerComparisionAdapter<T>: IComparer<T>
    {
        private readonly Comparison<T> comparision;

        public ComparerComparisionAdapter(Comparison<T> comparision )
        {
            this.comparision = comparision;
        } 

        public int Compare(T x, T y) => comparision(x, y);

    }
}
