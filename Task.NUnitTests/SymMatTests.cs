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
    public class SymMatTests
    {
        [Test]
        public void Constructor_test()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 2, 1, 0 }, { 3, 0, 1 } };
            SymmetricalMat<int> ctor = new SymmetricalMat<int>(test);
        }

        [Test]
        public void Constructor_test_exception()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Assert.Throws<ArgumentException>(() => new SymmetricalMat<int>(test));
        }

        [Test]
        public void Set_Get_Test()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, { 0, 0, 8 } };
            SymmetricalMat<int> mat = new SymmetricalMat<int>(test);
            Assert.AreEqual(mat[1, 1], 4);
            mat[1, 1] = 7;
            Assert.AreEqual(mat[1, 1], 7);
        }

        [Test]
        public void Set_test_exception()
        {
            int[,] test = new int[,] { { 5, 0, 0 }, { 0, 4, 0 }, { 0, 0, 8 } };
            SymmetricalMat<int> exc = new SymmetricalMat<int>(test);
            Assert.Throws<ArgumentException>(() => exc[1, 2] = 7);
        }

        [Test]
        public void Sum_mat()
        {
            int[,] test = new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
            int[,] test2 = new int[,] { { 1, 2, 3 }, { 2, 1, 0 }, { 3, 0, 1 } };
            int[,] exp = new int[,] { { 2, 3, 4 }, { 4, 3, 2 }, { 6, 3, 4 } };
            SquareMat<int> mat1 = new SquareMat<int>(test);
            SymmetricalMat<int> mat2 = new SymmetricalMat<int>(test2);
            SquareMat<int> expect = new SquareMat<int>(exp);
            CollectionAssert.AreEqual(expect, Extensions.Sum<int>(mat1, mat2));
        }
    }
}
