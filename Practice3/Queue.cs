using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    public class Queue
    {
        private List list = new List();
        public void Enqueue(Object item)
        {
            list.AddLast(item);
        }

        public Object Dequeue()
        {
            Object temp = list.GetFirst();
            list.RemoveFirst();
            return temp;
        }
        public Object Peek()
        {
            if (list.Count == 0)
                return null;
            return list.GetFirst();
        }
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
        public void Print()
        {
            list.PrintToConsole();
        }
    }
}
