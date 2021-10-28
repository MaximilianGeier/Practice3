using System;
using System.Text;

namespace Practice3
{
    class List
    {
        public int Count { get; private set; } = 0;
        private Node First;
        private Node Last;

        public void AddLast(Object value)
        {
            Node newEl = new Node(Last, null, value);
            if (Last != null)
                Last.Next = newEl;
            Last = newEl;

            Count++;
        }
        public void AddFirst(Object value)
        {
            Node newEl = new Node(null, First, value);
            if (First != null)
                First.Previous = newEl;
            First = newEl;

            Count++;
        }

        public void Remove(Object value)
        {
            Node node = Last;
            while (node != null)
            {
                if (node.Value == value)
                {
                    DeliteNode(node);
                }
            }
        }
        public void RemoveAt(int index)
        {
            Node node = First;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    DeliteNode(node);
                    return;
                }
                else
                {
                    node = node.Next;
                }
            }
        }
        public void RemoveFirst()
        {
            DeliteNode(First);
        }
        public void RemoveLast()
        {
            DeliteNode(Last);
        }
        private void DeliteNode(Node node)
        {
            if (First == Last)
            {
                First = null;
                Last = null;
            }
            else if (node == First)
            {
                First = node.Next;
                node.Next.Previous = null;
            }
            else if (node == Last)
            {
                Last = node.Previous;
                node.Previous.Next = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
            }

            Count--;
        }

        public Object this[int index]
        {
            get
            {
                Node node = First;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        return node.Value;
                    else
                        node = node.Next;
                }
                return null;
            }
            set
            {
                Node node = First;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        node.Value = value;
                    else
                        node = node.Next;
                }
            }
        }
    }
    class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Object Value { get; set; }
        public Node(Node previous, Node next, Object value)
        {
            Previous = previous;
            Next = next;
            Value = value;
        }
    }
}
