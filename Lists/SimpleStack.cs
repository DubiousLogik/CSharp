using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class SimpleStack<T>
    {
        /* ************************************************
         * SimpleStack.cs
         * 
         * Purpose:  Implement a functioning stack with Push, Pop and Peek methods for generic payloads.
         * 
         * Goal:  Learn how to implement a stack, and to learn C# Generics. 
         *   
         * Design Choices:  I chose to implement this with a linked list approach, where each node on the 
         *   stack is aware of its previous node.  The node at the bottom of the stack (the first one
         *   added) will have a previous node == null.
         *   
         * Author:  Robbie Devine, 17 Jun 2015  
         * ************************************************
        */
        private StackNode<T> topOfStack;
        public bool IsEmpty;

        public SimpleStack() {}

        public void Push(T data)
        {
            StackNode<T> newNode = new StackNode<T>(data);
            if (topOfStack == null)
            {
                newNode.PreviousNode = null;
                topOfStack = newNode;
                IsEmpty = false;
            }
            else
            {
                newNode.PreviousNode = topOfStack;
                topOfStack = newNode;
            }
        }

        public T Pop()
        {
            if (topOfStack != null)
            {
                T result = topOfStack.Payload;
                topOfStack = topOfStack.PreviousNode;  //this will set topOfStack == null when popping last node
                if (topOfStack == null)
                {
                    IsEmpty = true;
                }
                return result;
            }
            else
            {
                IsEmpty = true;
                return default(T);
            }
        }

        public T Peek()
        {
            if (topOfStack != null)
            {
                return topOfStack.Payload;
            }
            else
            {
                return default(T);
            }
        }

        private class StackNode<T>
        {
            public StackNode<T> PreviousNode { get; set; }
            public T Payload { get; private set; }

            public StackNode(T data)
            {
                Payload = data;
            }
        }
    }
}
