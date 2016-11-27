using System;

namespace Task01.Logic
{
    public class ElementChangeEventArgs<T>:EventArgs
    {
        public T Previous;
        public T Current;
        public int row, col;

        public ElementChangeEventArgs(T previous, T current, int row, int col)
        {
            Previous = previous;
            Current = current;
            this.row = row;
            this.col = col;
        }
    }
}
