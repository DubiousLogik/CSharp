using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringsAndText
{
    [TestClass]
    public class StringManipulatorTests
    {
        [TestMethod]
        public void StringManipulatorSort1()
        {
            string source = "thestring";
            string expectedResult = "eghinrstt";

            Char[] sourceChars = StringManipulator.SortCharacters(source);
            string actualResult = new string(sourceChars);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StringManipulatorSort2()
        {
            string source = "a";
            string expectedResult = "a";

            Char[] sourceChars = StringManipulator.SortCharacters(source);
            string actualResult = new string(sourceChars);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StringManipulatorSort3()
        {
            string source = "";
            string expectedResult = "";

            Char[] sourceChars = StringManipulator.SortCharacters(source);
            string actualResult = new string(sourceChars);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StringManipulatorRemove1()
        {
            string source = "a";
            string characterToRemove = "a";
            string expectedResult = "";

            string actualResult = StringManipulator.RemoveCharacter(source, characterToRemove);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StringManipulatorRemove2()
        {
            string source = "a";
            string characterToRemove = "b";
            string expectedResult = "a";

            string actualResult = StringManipulator.RemoveCharacter(source, characterToRemove);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StringManipulatorRemove3()
        {
            string source = "a";
            string characterToRemove = "aa";
            string expectedResult = "a";

            string actualResult = StringManipulator.RemoveCharacter(source, characterToRemove);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
