using System;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stack();
            for (int i = 0; i < 5; i++)
            {
                st.Push(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(st.Pop());
            }
            Console.WriteLine(st.isEmpty());
        }
    }
}
