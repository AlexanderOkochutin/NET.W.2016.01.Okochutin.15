using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Logic.RefactoringExtension;
using Task01.Logic.Rafactoring;
using NUnit.Framework;
namespace Task.NUnitTests
{
    [TestFixture]
    public class DiagonalMatTests
    {
        [Test]
        public void Constructor_test()
        {
            int[,] test = new int[,] {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};
            DiagonalMatrix<int> ctor = new DiagonalMatrix<int>(test);
        }

        [Test]
        public void Constructor_test_exception()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(test));
        }

        [Test]
        public void Set_Get_Test()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, {0, 0, 8 } };
           DiagonalMatrix<int> mat = new DiagonalMatrix<int>(test);
            Assert.AreEqual(mat[1, 1], 4);
            mat[1, 1] = 7;
            Assert.AreEqual(mat[1, 1], 7);
        }

        [Test]
        public void Set_test_exception()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, { 0, 0, 8 } };
            DiagonalMatrix<int> exc = new DiagonalMatrix<int>(test);
            Assert.Throws<ArgumentException>(() => exc[1, 2] = 7);
        }

        [Test]
        public void Sum_mat()
        {
            int[,] test = new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
            int[,] test2 = new int[,] { { 1,0,0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] exp = new int[,] { { 2, 1, 1 }, { 2, 3, 2 }, {3,3, 4 } };
            SquareMatrix<int> mat1 = new SquareMatrix<int>(test);
            DiagonalMatrix<int> mat2 = new DiagonalMatrix<int>(test2);
            SquareMatrix<int> expect = new SquareMatrix<int>(exp);
            CollectionAssert.AreEqual(expect, Extension.Add<int>(mat1, mat2));
        }
    }
}
