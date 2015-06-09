using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringsAndText
{
    [TestClass]
    public class StringComparatorTests
    {
        [TestMethod]
        public void PermutationExact1()
        {
            string source = "StringOne";
            string candidate = "OneString";
            bool expectedIsExactPermutation = true;

            bool actualIsExactPermutation = StringComparator.PermutationExact(source, candidate);

            Assert.AreEqual(expectedIsExactPermutation, actualIsExactPermutation);
        }

        [TestMethod]
        public void PermutationExact2()
        {
            string source = "StringOne";
            string candidate = "oneString";
            bool expectedIsExactPermutation = false;

            bool actualIsExactPermutation = StringComparator.PermutationExact(source, candidate);

            Assert.AreEqual(expectedIsExactPermutation, actualIsExactPermutation);
        }

        [TestMethod]
        public void PermutationExact3()
        {
            string source = "";
            string candidate = "";
            bool expectedIsExactPermutation = true;

            bool actualIsExactPermutation = StringComparator.PermutationExact(source, candidate);

            Assert.AreEqual(expectedIsExactPermutation, actualIsExactPermutation);
        }

        [TestMethod]
        public void PermutationExact4()
        {
            string source = "";
            string candidate = " ";
            bool expectedIsExactPermutation = false;

            bool actualIsExactPermutation = StringComparator.PermutationExact(source, candidate);

            Assert.AreEqual(expectedIsExactPermutation, actualIsExactPermutation);
        }

        [TestMethod]
        public void Contains1()
        {
            string source = "bigString";
            string candidate = "big";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.Contains(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void Contains2()
        {
            string source = "bigString";
            string candidate = "ring";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.Contains(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void Contains3()
        {
            string source = "bigString";
            string candidate = "biG";
            bool expectedDoesContain = false;

            bool actualDoesContain = StringComparator.Contains(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void Contains4()
        {
            string source = "big";
            string candidate = "bigString";
            bool expectedDoesContain = false;

            bool actualDoesContain = StringComparator.Contains(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void Contains5()
        {
            string source = "big";
            string candidate = "";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.Contains(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring1()
        {
            string source = "OneString";
            string candidate = "nOte";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring2()
        {
            string source = "OneString";
            string candidate = "StringOne";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring3()
        {
            string source = "OneString";
            string candidate = "S";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring4()
        {
            string source = "OneString";
            string candidate = "s";
            bool expectedDoesContain = false;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring5()
        {
            string source = "OneString";
            string candidate = "";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring6()
        {
            string source = "OneString";
            string candidate = "O";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring7()
        {
            string source = "OneString";
            string candidate = "g";
            bool expectedDoesContain = true;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring8()
        {
            string source = "OneString";
            string candidate = "nOtte";
            bool expectedDoesContain = false;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

        [TestMethod]
        public void PermutationSubstring9()
        {
            string source = "One";
            string candidate = "nOtte";
            bool expectedDoesContain = false;

            bool actualDoesContain = StringComparator.PermutationSubstring(source, candidate);

            Assert.AreEqual(expectedDoesContain, actualDoesContain);
        }

    }
}
