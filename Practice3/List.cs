using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    class List
    {
        private Node First;
        private Node Last;
        public void Add(Object value)
        {
            Node newEl = new Node(value);
            Last.Next = newEl;
            Last = newEl;
        }
        public void Remove(Object value)
        {
            Node element = Last;
            while (element != null)
            {
                if (element.Value == value)
                {
                    if (First == Last)
                    {
                        First = null;
                        Last = null;
                    }
                    else if (element == First)
                    {
                        First = element.Next;
                        element.Next.Previous = null;
                    }
                    else if (element == Last)
                    {
                        Last = element.Previous;
                        element.Previous.Next = null;
                    }
                    else
                    {
                        element.Next.Previous = element.Previous;
                        element.Previous.Next = element.Next;
                    }
                }
            }
        }
        public void RemoveAt(int index)
        {

        }
    }
    class Node
    {
        public Node Next;
        public Node Previous;
        public Object Value;
        public Node(Object value)
        {
            Value = value;
        }
    }
}
