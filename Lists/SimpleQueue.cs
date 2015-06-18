using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    /* ************************************************
     * SimpleQueue.cs
     * 
     * Purpose:  Implement a functioning queue (FIFO) with Enqueue and Dequeue methods for generic payloads.
     * 
     * Goal:  Learn how to implement a queue capabilities, and to learn C# Generics. 
     *   
     * Design Choices:  I chose to implement this with a singly linked list approach.  This pattern is
     *   the same as a regular linked list except that you don't offer the ability to traverse the whole
     *   list, there is only Enqueue (add to end) and Dequeue (remove from front).  
     *   
     * Author:  Robbie Devine, 17 Jun 2015  
     * ************************************************
    */
    public class SimpleQueue<T>
    {
        public bool IsEmpty { get; private set; }

        private QueueNode<T> FirstNode;
        private QueueNode<T> LastNode;

        public SimpleQueue()
        {
            IsEmpty = true;
            FirstNode = null;
            LastNode = null;
        }

        public void Enqueue(T data)
        {
            QueueNode<T> newNode = new QueueNode<T>(data);
            newNode.NextNode = null;  //adding to the end

            if (IsEmpty)
            {
                FirstNode = newNode;
                LastNode = FirstNode;
                IsEmpty = false;
            }
            else
            {
                LastNode.NextNode = newNode;
                LastNode = newNode;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            else
            {
                T result = FirstNode.Payload;
                RemoveFirstNode();
                return result;
            }
        }

        public void RemoveFirstNode()
        {
            FirstNode = FirstNode.NextNode;
            if (FirstNode == null)
            {
                IsEmpty = true;
            }
        }

        private class QueueNode<T>
        {
            public T Payload { get; private set; }
            public QueueNode<T> NextNode { get; set; }

            public QueueNode(T data)
            {
                Payload = data;
            }

        }
    }
}
