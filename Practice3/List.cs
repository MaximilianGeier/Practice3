using System;
using System.Text;

namespace Practice3
{
    class List
    {
        public int Count { get; private set; } = 0;
        private Node first;
        private Node last;

        public void AddLast(Object value)
        {
            Node newEl = new Node(last, null, value);
            if (last != null)
                last.Next = newEl;
            last = newEl;
            if (first == null)
                first = newEl;

            Count++;
        }
        public void AddFirst(Object value)
        {
            Node newEl = new Node(null, first, value);
            if (first != null)
                first.Previous = newEl;
            first = newEl;
            if (last == null)
                last = newEl;

            Count++;
        }

        public void Remove(object value)
        {
            Node node = first;
            while (node != null)
            {
                if (node.Value.Equals(value))
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
        public void RemoveAt(int index)
        {
            Node node = first;
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
            DeliteNode(first);
        }
        public void RemoveLast()
        {
            DeliteNode(last);
        }
        private void DeliteNode(Node node)
        {
            if (first == last)
            {
                first = null;
                last = null;
            }
            else if (node == first)
            {
                first = node.Next;
                node.Next.Previous = null;
            }
            else if (node == last)
            {
                last = node.Previous;
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
                Node node = first;
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
                Node node = first;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        node.Value = value;
                    else
                        node = node.Next;
                }
            }
        }

        public Object GetFirst()
        {
            return first.Value;
        }
        public Object GetLast()
        {
            return last.Value;
        }

        public void PrintToConsole()
        {
            Node node = first;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
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
    
}
