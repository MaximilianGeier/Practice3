using System;
using System.IO;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var st = new Stack();
            st.Push(12);
            st.Top();
            st.Top();

            Queue instractions = Parser.GetFileData(Directory.GetCurrentDirectory() + @"\\..\\..\\.." + @"\input.txt");
            Parser.ExecuteInstractions(instractions);*/

            /*            List list = new List();

                        for (int i = 0; i < 6; i++)
                        {
                            list.AddLast(i);
                        }
                        list.AddInIncreasingOrder(3);
                        list.AddInIncreasingOrder(4);
                        list.AddInIncreasingOrder(-1);
                        list.AddInIncreasingOrder(6);
                        list.PrintToConsole();

                        list.Replace(-3,3);
                        list.PrintToConsole();*/

            Queue inst = Parser.GetFileData("C://test.txt");
            Parser.ExecuteInstractionsToQueue(inst);

            /*list.AddLast('a');
            list.AddLast('b');
            list.AddLast('c');
            list.AddLast('d');
            list.AddInIncreasingOrder('c');
            list.PrintToConsole();*/
        }
    }
}
