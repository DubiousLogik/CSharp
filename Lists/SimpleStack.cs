﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    /* ************************************************
     * SimpleStack.cs
     * 
     * Purpose:  Implement a functioning stack (LIFO) with Push, Pop and Peek methods for generic payloads.
     * 
     * Goal:  Learn how to implement a stack, and to learn C# Generics. 
     *   
     * Design Choices:  I chose to implement this with a linked list approach, where each node on the 
     *   stack is aware of its previous node.  The node at the bottom of the stack (the first one
     *   added) will have a previous node == null.  In this approach the container SimpleStack does
     *   not maintain pointers to all nodes, just the top node.  
     *   
     * Author:  Robbie Devine, 17 Jun 2015  
     * ************************************************
    */

    public class SimpleStack<T>
    {
        private StackNode<T> topOfStack;
        public bool IsEmpty;

        public SimpleStack() 
        {
            IsEmpty = true;
        }

        public void Push(T data)
        {
            StackNode<T> newNode = new StackNode<T>(data);
            if (IsEmpty)
            {
                newNode.PreviousNode = null;
            }
            else
            {
                newNode.PreviousNode = topOfStack;
            }
            topOfStack = newNode;
            IsEmpty = false;
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                T result = topOfStack.Payload;
                RemoveTopOfStack();
                return result;
            }
            else
            {
                return default(T);
            }
        }

        private void RemoveTopOfStack()
        {
            topOfStack = topOfStack.PreviousNode;  //this will set topOfStack == null when popping last node
            if (topOfStack == null)
            {
                IsEmpty = true;
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
