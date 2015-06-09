using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class SinglyLinkedList
    {
        Node firstNode = null;

        public SinglyLinkedList() {}

        public void AddNode(string input) 
        {
            if (firstNode == null)
            {
                firstNode = new Node(input);
            }
            else
            {
                firstNode.AddToEnd(new Node(input));
            }
        }

        public void OutputNodeValuesToConsole()
        {
            if (firstNode == null) 
            { 
                return; 
            }

            Node thisNode = firstNode;
            Console.WriteLine("Current Node data payload : {0}", thisNode.Data);
            while (thisNode.nextNode != null)
            {
                thisNode = thisNode.nextNode;
                Console.WriteLine("Current Node data payload : {0}", thisNode.Data);
            }
        }

        public string OutputNodeValuesToString()
        {
            if (firstNode == null)
            {
                return "";
            }

            StringBuilder result = new StringBuilder();

            Node thisNode = firstNode;
            result.Append(thisNode.Data);

            while (thisNode.nextNode != null)
            {
                thisNode = thisNode.nextNode;
                result.Append(thisNode.Data);
            }

            return result.ToString();
        }
    }

    public class Node
    {
        public Node nextNode { get; private set; }
        public string Data { get; private set; }

        public Node(string input)
        {
            Data = input;
        }

        public void AddToEnd(Node newNode)
        {
            Node thisNode = this;
            while (thisNode.nextNode != null)
            {
                thisNode = thisNode.nextNode;
            }
            thisNode.nextNode = newNode;
        }
    }
}
