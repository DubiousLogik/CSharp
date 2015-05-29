using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryAndHexWorkbook
{
    [TestClass]
    public class HexConverterTests
    {
        [TestMethod]
        public void HexTestCase1()
        {
            const string testNumber = "f";
            const int expectedNumber = 15;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase2()
        {
            const string testNumber = "2a";
            const int expectedNumber = 42;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase3()
        {
            const string testNumber = "fF";
            const int expectedNumber = 255;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase4()
        {
            const string testNumber = "ffg";
            const int expectedNumber = -1;
            int actualNumber = -1;
            const bool expectedValidity = false;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase5()
        {
            const string testNumber = "1000";
            const int expectedNumber = 4096;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase6()
        {
            const string testNumber = "10000";
            const int expectedNumber = 65536;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase7()
        {
            const string testNumber = "0";
            const int expectedNumber = 0;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase8()
        {
            const string testNumber = "1";
            const int expectedNumber = 1;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void HexTestCase9()
        {
            const string testNumber = "-1";
            const int expectedNumber = -1;
            int actualNumber = -1;
            const bool expectedValidity = false;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

         [TestMethod]
        public void HexTestCase10()
        {
            const string testNumber = "fffffff";
            const int expectedNumber = 268435455;
            int actualNumber = -1;
            const bool expectedValidity = true;
            bool actualValidity = false;

            actualValidity = HexConverter.TryParseToInt32(testNumber, out actualNumber);

            Assert.AreEqual(expectedValidity, actualValidity);
            Assert.AreEqual(expectedNumber, actualNumber);
        }
    }
}
