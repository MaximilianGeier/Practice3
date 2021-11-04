using System;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stack();
            st.Push(12);
            st.Top();
            st.Top();

            Queue instractions = Parser.GetFileData(@"C:\\test.txt");
            Parser.ExecuteInstractions(instractions);
        }
    }
}
