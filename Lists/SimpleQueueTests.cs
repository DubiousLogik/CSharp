using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Lists
{
    [TestClass]
    public class SimpleQueueTests
    {
        [TestMethod]
        public void SimpleQueueTest1()
        {
            string expectedResult = null;

            SimpleQueue<string> q = new SimpleQueue<string>();
            
            string actualResult = q.Dequeue();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SimpleQueueTest2()
        {
            string expectedResult = "one,two";

            SimpleQueue<string> q = new SimpleQueue<string>();
            q.Enqueue("one");
            q.Enqueue("two");

            string actualResult = q.Dequeue() + "," + q.Dequeue();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SimpleQueueTest3()
        {
            string expectedResult = "0123456789";

            SimpleQueue<int> q = new SimpleQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }

            StringBuilder sb = new StringBuilder();

            while (!q.IsEmpty)
            {
                sb.Append(q.Dequeue().ToString());
            }

            string actualResult = sb.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
