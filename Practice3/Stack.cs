using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    class Stack
    {
        public List<object> St = new List<object>();
        public void Push(object temp)
        {
            St.Add(temp);
        }

        public object Pop()
        {
            object temp = St[^1];
            St.Remove(St.Count - 1);
            return temp;
        }

        public object Top()
        {
            return St[^1];
        }

        public bool isEmpty()
        {
            if (St.Count == 0)
                return true;
            return false;
        }

        public void Print()
        {
            while(St.Count != 0)
            {
                Console.WriteLine(St[^1]);
                St.Remove(St.Count + 1);
            }
        }
    }
}
