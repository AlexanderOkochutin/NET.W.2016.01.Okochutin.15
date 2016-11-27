namespace Task01.Logic
{
    public interface IMatrixVsitor<T>
    {
        void Visit(SquareMat<T> otherMat);
    }
}
