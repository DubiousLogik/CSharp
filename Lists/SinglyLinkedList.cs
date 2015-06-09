using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    /* ************************************************
     * SinglyLinkedList.cs
     * 
     * Purpose:  Implement a singly linked list with ability to add nodes and return the output of the list
     * 
     * Goal:  Learn how to create linked lists, specifically the 'next node' pointer.  In C# I'm not 
     *   explicitly manipulating pointers, however the NextNode object contained within the current Node
     *   winds up being a pointer under the covers.  I still have to manage this relationship properly or
     *   else I end up with orphans or null references.
     *   
     * Design Choices:  I chose to separate the SinglyLinkedList class from the underlying Node implementation.
     *   The intent is that the user could interact with the SinglyLinkedList class and not need to know about
     *   the Node class.  I added the lastNode element as a perf optimization, so that you don't re-traverse
     *   the entire list every time you add an element to the end, which matters a lot as the list gets large.
     *   With this optimization it becomes a viable StringBuilder as well.
     *   
     * Author:  Robbie Devine, 08 Jun 2015  
     * ************************************************
    */
    public class SinglyLinkedList
    {
        Node firstNode = null;
        Node lastNode = null;

        public SinglyLinkedList() {}

        public void AddNodeToEnd(string input) 
        {
            if (firstNode == null)
            {
                firstNode = new Node(input);
                lastNode = firstNode;
            }
            else
            {
                Node thisNode = new Node(input);
                lastNode.AddNode(thisNode);
                lastNode = thisNode;
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
            while (thisNode.NextNode != null)
            {
                thisNode = thisNode.NextNode;
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

            while (thisNode.NextNode != null)
            {
                thisNode = thisNode.NextNode;
                result.Append(thisNode.Data);
            }

            return result.ToString();
        }

    }

    public class Node
    {
        public Node NextNode { get; private set; }
        public string Data { get; private set; }

        public Node(string input)
        {
            Data = input;
        }

        public void AddNode(Node newNode)
        {
            Node lastNode = this.ReadToEnd();
            lastNode.NextNode = newNode;
        }

        public Node ReadToEnd()
        {
            Node thisNode = this;
            while (thisNode.NextNode != null)
            {
                thisNode = thisNode.NextNode;
            }
            return thisNode;
        }
    }

}
