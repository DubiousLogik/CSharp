using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void SinglyLinkedListTest1()
        {
            string expectedListValues = "";
            SinglyLinkedList list = new SinglyLinkedList();

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest2()
        {
            string expectedListValues = "0";
            SinglyLinkedList list = new SinglyLinkedList();

            list.AddNode("0");

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest3()
        {
            string expectedListValues = "0123456789";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNode(i.ToString());
            }

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest4()
        {
            string expectedListValues = "The man in the moon likes gouda.";
            SinglyLinkedList list = new SinglyLinkedList();

            list.AddNode("The ");
            list.AddNode("man ");
            list.AddNode("in ");
            list.AddNode("the ");
            list.AddNode("moon ");
            list.AddNode("likes ");
            list.AddNode("gouda.");

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }
    }
}
