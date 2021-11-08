using System;
using System.IO;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ry"); // нужно для корректного перевода чисел с плавающей запятой из строки

            /*var st = new Stack();
            st.Push(12);
            st.Top();
            st.Top();

            Queue instractions = Parser.GetFileData(Directory.GetCurrentDirectory() + @"\\..\\..\\.." + @"\input.txt");
            Parser.ExecuteInstractions(instractions);*/
            string expression = Parser.GetStringsFromFile("../../../expression.txt")[0];
            Console.WriteLine(expression);
            List parsedExp = RPN.ParseExpression(expression);
            parsedExp = RPN.ParseOPZFromString(Parser.GetStringsFromFile("../../../expressionRPN.txt")[0]); 
            for (int i = 0; i < parsedExp.Count; i++)
            {
                Console.Write(parsedExp[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(RPN.Calculate(parsedExp));

            

            /*list.AddLast('a');
            list.AddLast('b');
            list.AddLast('c');
            list.AddLast('d');
            list.AddInIncreasingOrder('c');
            list.PrintToConsole();*/
        }

        
    }
}
