﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists
{
    [TestClass]
    public class StringListTest
    {
        [TestMethod]
        public void StringListTest1()
        {
            StringList stringList = new StringList();
            int expectedMaxSize = 4;
            int expectedNextIndexValue = 0;

            int actualMaxSize = stringList.MaxSize;
            int actualNextIndexValue = stringList.NextIndexValue;

            Assert.AreEqual(expectedMaxSize, actualMaxSize);
            Assert.AreEqual(expectedNextIndexValue, actualNextIndexValue);
        }

        [TestMethod]
        public void StringListTest2()
        {
            StringList stringList = new StringList();
            int expectedMaxSize = 8;
            int expectedNextIndexValue = 5;
            int expectedCountOfCharacters = 5;

            for (int i = 0; i < 5; i++)
            {
                stringList.Add(i.ToString());
            }

            int actualMaxSize = stringList.MaxSize;
            int actualNextIndexValue = stringList.NextIndexValue;
            int actualCountOfCharacters = stringList.CountOfCharacters;

            Assert.AreEqual(expectedMaxSize, actualMaxSize);
            Assert.AreEqual(expectedNextIndexValue, actualNextIndexValue);
            Assert.AreEqual(expectedCountOfCharacters, actualCountOfCharacters);
        }

        [TestMethod]
        public void StringListTest3()
        {
            StringList stringList = new StringList();
            int expectedMaxSize = 16;
            int expectedNextIndexValue = 10;
            int expectedCountOfCharacters = 10;

            for (int i = 0; i < 10; i++)
            {
                stringList.Add(i.ToString());
            }

            int actualMaxSize = stringList.MaxSize;
            int actualNextIndexValue = stringList.NextIndexValue;
            int actualCountOfCharacters = stringList.CountOfCharacters;

            Assert.AreEqual(expectedMaxSize, actualMaxSize);
            Assert.AreEqual(expectedNextIndexValue, actualNextIndexValue);
            Assert.AreEqual(expectedCountOfCharacters, actualCountOfCharacters);
        }

        [TestMethod]
        public void StringListTest4()
        {
            StringList stringList = new StringList();
            int expectedMaxSize = 16;
            int expectedNextIndexValue = 12;
            int expectedCountOfCharacters = 70;

            stringList.Add("the");
            stringList.Add(" lazy");
            stringList.Add(" rabbit");
            stringList.Add(" slept");
            stringList.Add(" longer");
            stringList.Add(" than");
            stringList.Add(" the");
            stringList.Add(" doormouse");
            stringList.Add(",");
            stringList.Add(" upsetting");
            stringList.Add(" the");
            stringList.Add(" hatter.");

            int actualMaxSize = stringList.MaxSize;
            int actualNextIndexValue = stringList.NextIndexValue;
            int actualCountOfCharacters = stringList.CountOfCharacters;

            Assert.AreEqual(expectedMaxSize, actualMaxSize);
            Assert.AreEqual(expectedNextIndexValue, actualNextIndexValue);
            Assert.AreEqual(expectedCountOfCharacters, actualCountOfCharacters);
        }
    }
}