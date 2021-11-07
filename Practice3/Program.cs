using System;
using System.IO;

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

            Queue instractions = Parser.GetFileData(Directory.GetCurrentDirectory() + @"\\..\\..\\.." + @"\TextFile.txt");
            Parser.ExecuteInstractions(instractions);
        }
    }
}
