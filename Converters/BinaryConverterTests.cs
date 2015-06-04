using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryAndHexWorkbook
{
    [TestClass]
    public class BinaryConverterTests
    {
        [TestMethod]
        public void BinaryConverterTest1()
        {
            const string testNumber = "0";
            const int expectedNumber = 0;
            const bool expectedValidity = true; 
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest2()
        {
            const string testNumber = "1";
            const int expectedNumber = 1;
            const bool expectedValidity = true;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest3()
        {
            const string testNumber = "1010";
            const int expectedNumber = 10;
            const bool expectedValidity = true;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest4()
        {
            const string testNumber = "101f";
            const int expectedNumber = -1;
            const bool expectedValidity = false;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest5()
        {
            const string testNumber = "00101010";
            const int expectedNumber = 42;
            const bool expectedValidity = true;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest6()
        {
            const string testNumber = "110";
            const int expectedNumber = 6;
            const bool expectedValidity = true;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }

        [TestMethod]
        public void BinaryConverterTest7()
        {
            const string testNumber = "-1";
            const int expectedNumber = -1;
            const bool expectedValidity = false;
            bool actualValidity = false;
            int actualNumber = -1;

            actualValidity = BinaryConverter.TryParseStringToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(expectedValidity, actualValidity);
        }
    }
}
