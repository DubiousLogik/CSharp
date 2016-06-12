using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzles
{
    [TestClass]
    public class ReturnMaxNumberTest
    {
        [TestMethod]
        public void Permutation01()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(3, 4);
            int expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation02()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(6, 4);
            int expectedResult = 6;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation03()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(-2, 4);
            int expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation04()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(4,-2);
            int expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation05()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(-4, 2);
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation06()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(2,-4);
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation07()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(-2, -4);
            int expectedResult = -2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation08()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(-4, -2);
            int expectedResult = -2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation09()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(-4, -4);
            int expectedResult = -4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation10()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(4, 4);
            int expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Permutation11()
        {
            int actualResult = ReturnMaxNumber.ReturnMaxInt(0, 0);
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
