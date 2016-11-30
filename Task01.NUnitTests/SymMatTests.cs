using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Logic.Rafactoring;
using Task01.Logic.RefactoringExtension;
using NUnit.Framework;
namespace Task.NUnitTests
{
    [TestFixture]
    public class SymMatTests
    {
        [Test]
        public void Constructor_test()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 2, 1, 0 }, { 3, 0, 1 } };
            SymmetricalMatrix<int> ctor = new SymmetricalMatrix<int>(test);
        }

        [Test]
        public void Constructor_test_exception()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(test));
        }

        [Test]
        public void Set_Get_Test()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, { 0, 0, 8 } };
            SymmetricalMatrix<int> mat = new SymmetricalMatrix<int>(test);
            Assert.AreEqual(mat[1, 1], 4);
            mat[1, 1] = 7;
            Assert.AreEqual(mat[1, 1], 7);
        }

        [Test]
        public void Set_test_exception()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, { 0, 0, 8 } };
            SymmetricalMatrix<int> exc = new SymmetricalMatrix<int>(test);
            Assert.Throws<ArgumentException>(() => exc[1, 2] = 7);
        }

        [Test]
        public void Sum_mat()
        {
            int[,] testData1 = new int[,] {{1, 0, 0}, {0, 2, 0}, {0, 0, 3}};
            int[,] testData2 = new int[,] {{1, 0, 0}, {0, 2, 0}, {0, 0, 3}};
            int[,] testData3 = new int[,] {{2, 0, 0}, {0, 4, 0}, {0, 0, 6}};
            DiagonalMatrix<int> test1 = new DiagonalMatrix<int>(testData1);
            DiagonalMatrix<int> test2 = new DiagonalMatrix<int>(testData2);
            AbstractSquareMatrix<int> exp = new DiagonalMatrix<int>(testData3);
            CollectionAssert.AreEqual(exp, Extension.Add(test1, test2));
        }
    }
}
