using Microsoft.CSharp.RuntimeBinder;
using Task01.Logic.Rafactoring;

namespace Task01.Logic.RefactoringExtension
{
    public static class Extension
    {
        public static AbstractSquareMatrix<T> Add<T>(AbstractSquareMatrix<T> lft, AbstractSquareMatrix<T> rght)
        {
           dynamic left = lft;
           dynamic right = rght;
           if(lft.Size != rght.Size) throw new ExtensionMatOperationException("both matrix must be the same size");
            return MatAdd( left,  right);
        }

        private static AbstractSquareMatrix<T> MatAdd<T>(SquareMatrix<T> leftMatrix, AbstractSquareMatrix<T> rightMatrix)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(leftMatrix.Size);
            try
            {
                for (int i = 0; i < leftMatrix.Size; i++)
                    for (int j = 0; j < rightMatrix.Size; j++)
                        result[i, j] = (dynamic)leftMatrix[i, j] + rightMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
              throw new ExtensionMatOperationException("this type is not support operator '+' ");
            }
            return result;
        }

        private static AbstractSquareMatrix<T> Sum<T>
          (SymmetricalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
          => MatAdd(secondMatrix, firstMatrix);

        private static AbstractSquareMatrix<T> MatAdd<T>
           (SymmetricalMatrix<T> firstMatrix, AbstractSquareMatrix<T> secondMatrix)
        {
            SymmetricalMatrix<T> result = new SymmetricalMatrix<T>(firstMatrix.Size);
            try
            {
                for (int i = 0; i < firstMatrix.Size; i++)
                    for (int j = 0; j <= i; j++)
                        result[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
                throw new ExtensionMatOperationException("this type is not support operator '+' ");
                    
            }
            return result;
        }

        private static AbstractSquareMatrix<T> Sum<T>
                    (DiagonalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
                    => MatAdd(secondMatrix, firstMatrix);

        private static AbstractSquareMatrix<T> MatAdd<T>
            (DiagonalMatrix<T> firstMatrix, SymmetricalMatrix<T> secondMatrix)
            => MatAdd(secondMatrix, firstMatrix);

        private static AbstractSquareMatrix<T> MatAdd<T>
            (DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(firstMatrix.Size);
            try
            {
                for (int i = 0; i < firstMatrix.Size; i++)
                    result[i, i] = (dynamic)firstMatrix[i, i] + secondMatrix[i, i];
            }
            catch (RuntimeBinderException)
            {
                throw new ExtensionMatOperationException("this type is not support operator '+'");
            }
            return result;
        }
    }
}
