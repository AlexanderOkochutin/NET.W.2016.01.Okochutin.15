using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Logic;
using Task01.Extensions;
using NUnit.Framework;
namespace Task.NUnitTests
{
    [TestFixture]
    public class SquareMatTests
    {
        [Test]
        public void Constructor_test()
        {
            int[,] test = new int[,] {{1,2,3}, {3,4,5}, {6,7,8}};
            SquareMat<int> ctor = new SquareMat<int>(test);
        }

        [Test]
        public void Constructor_test_exception()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 }, {1,2,3} };
            Assert.Throws<ArgumentException>(() => new SquareMat<int>(test));
        }

        [Test]
        public void Set_Get_Test()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
            SquareMat<int> mat = new SquareMat<int>(test);
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
            SquareMat<int> mat1 = new SquareMat<int>(test);
            SquareMat<int> mat2 = new SquareMat<int>(test2);
            SquareMat<int> expect = new SquareMat<int>(exp);
            CollectionAssert.AreEqual(expect,Extensions.Sum<int>(mat1,mat2));
        }
    }
}
