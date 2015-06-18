using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Lists
{
    [TestClass]
    public class SimpleStackTests
    {
        [TestMethod]
        public void SimpleStackTest1()
        {
            string expectedResult = null;
            bool expectedEmpty = true;

            SimpleStack<string> s = new SimpleStack<string>();
            string actualResult = s.Pop();
            bool actualEmpty = s.IsEmpty;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void SimpleStackTest2()
        {
            int expectedResult = 0;
            bool expectedEmpty = true;

            SimpleStack<int> s = new SimpleStack<int>();
            int actualResult = s.Pop();
            bool actualEmpty = s.IsEmpty;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void SimpleStackTest3()
        {
            string expectedResult = "9876543210";

            SimpleStack<int> s = new SimpleStack<int>();

            for (int i = 0; i < 10; i++)
            {
                s.Push(i);
            }

            StringBuilder sb = new StringBuilder();
            while (!s.IsEmpty)
            {
                sb.Append(s.Pop().ToString());
            }
            string actualResult = sb.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SimpleStackTest4()
        {
            string expectedResult = "02468 97531";

            SimpleStack<int> s = new SimpleStack<int>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                s.Push(i);
                if ((i % 2) == 0)
                {
                    sb.Append(s.Pop().ToString());
                }
            }

            sb.Append(" ");

            while (!s.IsEmpty)
            {
                sb.Append(s.Pop().ToString());
            }
            string actualResult = sb.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
