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
     * Purpose:  Implement a singly linked list with ability to add, get, and delete nodes, and return the 
     *   values of all nodes as a string
     * 
     * Goal:  Learn how to create linked lists, specifically the 'next node' pointer.  In C# I'm not 
     *   explicitly manipulating pointers, however the NextNode object contained within the current Node
     *   winds up being a pointer under the covers.  I still have to manage this relationship properly or
     *   else I end up with orphans or null references.
     *   
     * Design Choices:  I chose to separate the SinglyLinkedList class from the underlying Node implementation.
     *   The intent is that the user could interact with the SinglyLinkedList class and not need to know about
     *   the Node class.  Only the Node class can set the NextNode and Data elements.
     * 
     * Performance:  I added the lastNode element as a perf optimization, so that you don't re-traverse
     *   the entire list every time you add an element to the end, which matters a lot as the list gets large.
     *   With this optimization it becomes a viable as an alternate implementation of StringBuilder that does
     *   not use Arrays.
     *   
     * Author:  Robbie Devine, 08 Jun 2015  
     * ************************************************
    */
    public class SinglyLinkedList
    {
        Node firstNode = null;
        Node lastNode = null;
        Node currentNode = null;

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
                lastNode.AddNodeToEnd(thisNode);
                lastNode = thisNode;
            }
        }

        /// <summary>
        /// Returns the first node (head) of the list.  Advances the current node pointer to the first node.
        /// </summary>
        /// <returns>Returns the first node of the list</returns>
        public Node GetFirstNode() 
        {
            currentNode = firstNode;
            return firstNode;
        }

        /// <summary>
        /// Returns the next node after the current node.  May return null.  Advances the current node pointer to the next node.  If current node == null then the end of the list has been reached.
        /// </summary>
        /// <returns>returns next node after the current node.</returns>
        public Node GetNextNode()
        {
            currentNode = currentNode.NextNode;
            return currentNode;
        }

        public bool IsEndOfList()
        {
            return (currentNode == lastNode);
        }

        /// <summary>
        /// Inserts a node after the current node.  Does not advance the current node pointer.
        /// </summary>
        /// <param name="newNode">Node to be inserted to the list</param>
        public void InsertNodeAfter(Node newNode)
        {
            currentNode.AddNodeAfter(newNode);
        }

        //public void InsertNodeBefore(Node newNode)

        /// <summary>
        /// Deletes the current node and returns the next node.  Returns null if last node is deleted.
        /// </summary>
        /// <returns>Returns next node after the deleted node.  Returns null if last node is deleted. </returns>
        public Node DeleteCurrentNode()
        {
            if (currentNode == null)
            {
                Console.WriteLine("in currentNode == null");
                return null;
            } 
            else if (currentNode == firstNode) 
            {
                Console.WriteLine("in currentNode == firstNode");
                return this.DeleteFirstNode();
            }
            else if (currentNode == lastNode) 
            {
                Console.WriteLine("in currentNode == lastNode");
                return this.DeleteLastNode();
            }
            else
            {
                Console.WriteLine("in currentNode == thisNode");
                return this.DeleteThisNode();
            }

        }

        private Node DeleteFirstNode()
        {
            Node nodeToDelete = currentNode;
            firstNode = currentNode.NextNode;
            currentNode = firstNode;
            nodeToDelete = null;
            return currentNode;
        }

        private Node DeleteLastNode()
        {
            Node secondToLastNode = this.GetFirstNode();
            while (secondToLastNode.NextNode != lastNode)
            {
                secondToLastNode = this.GetNextNode();
            }

            secondToLastNode.SetAsLastNode();
            lastNode = null;
            lastNode = secondToLastNode;
            currentNode = null;
            return null;
        }

        private Node DeleteThisNode()
        {
            Node nextNode = currentNode.NextNode;
            currentNode.ReplaceWith(nextNode);
            nextNode = null;
            return currentNode;
        }

        public string OutputNodeValuesToString()
        {
            SinglyLinkedList thisList = this;

            if (firstNode == null)
            {
                return "";
            }

            StringBuilder result = new StringBuilder();

            Node thisNode = thisList.GetFirstNode();
            result.Append(thisNode.Data);

            while (thisNode.NextNode != null)
            {
                thisNode = thisList.GetNextNode();
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

        public void AddNodeToEnd(Node newNode)
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

        public void AddNodeAfter(Node newNode)
        {
            Node thisNode = this;
            Node nextNode = thisNode.NextNode;
            newNode.NextNode = nextNode;
            thisNode.NextNode = newNode;
        }

        public void SetAsLastNode()
        {
            this.NextNode = null;
        }

        public void ReplaceWith(Node replacementNode)
        {
            Node thisNode = this;
            thisNode.NextNode = replacementNode.NextNode;
            thisNode.Data = replacementNode.Data;
        }
    }

}
