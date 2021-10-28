using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    class Stack
    {
        private List list = new List();
        public void Push(object temp)
        {
            list.AddLast(temp);
        }

        public object Pop()
        {
            object temp = list.GetLast();
            list.RemoveLast();
            return temp;
        }

        public object Top()
        {
            return list.GetLast();
        }

        public bool isEmpty()
        {
            return list.Count == 0;
        }

        public void Print()
        {
            list.PrintToConsole();
        }
    }
}
