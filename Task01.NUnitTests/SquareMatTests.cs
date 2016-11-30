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
    public class SquareMatrixTests
    {
        [Test]
        public void Constructor_test()
        {
            int[,] test = new int[,] {{1,2,3}, {3,4,5}, {6,7,8}};
            SquareMatrix<int> ctor = new SquareMatrix<int>(test);
        }

        [Test]
        public void Constructor_test_exception()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 }, {1,2,3} };
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(test));
        }

        [Test]
        public void Set_Get_Test()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
            SquareMatrix<int> mat = new SquareMatrix<int>(test);
            Assert.AreEqual(mat[1,1],4);
            mat[1, 1] = 7;
            Assert.AreEqual(mat[1, 1], 7);
        }

        [Test]
        public void Sum_mat()
        {
            int[,] test = new int[,] { { 1, 1,1  }, { 2, 2, 2 }, { 3, 3,3 } };
            int[,] test2 = new int[,] { { 3, 3, 3 }, { 2, 2, 2 }, { 1, 1, 1 } };
            int[,] exp = new int[,] { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
            SquareMatrix<int> mat1 = new SquareMatrix<int>(test);
            SquareMatrix<int> mat2 = new SquareMatrix<int>(test2);
            SquareMatrix<int> expect = new SquareMatrix<int>(exp);
            CollectionAssert.AreEqual(expect,Extension.Add<int>(mat1,mat2));
        }
    }
}
