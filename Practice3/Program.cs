using System;
using System.Diagnostics;
using System.IO;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ry"); // нужно для корректного перевода чисел с плавающей запятой из строки
            */
            /*var st = new Stack();
            st.Push(12);
            st.Top();
            st.Top();

            Queue instractions = Parser.GetFileData(Directory.GetCurrentDirectory() + @"\\..\\..\\.." + @"\input.txt");
            Parser.ExecuteInstractions(instractions);*/

            /*            string expression = Parser.GetStringsFromFile("../../../expression.txt")[0];
                        Console.WriteLine(expression);
                        List parsedExp = PostfixNotation.GetPostfixNotation(expression);
                        parsedExp = PostfixNotation.GetListOfTokensFromPNString(Parser.GetStringsFromFile("../../../expressionRPN.txt")[0]); 
                        for (int i = 0; i < parsedExp.Count; i++)
                        {
                            Console.Write(parsedExp[i] + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine(PostfixNotation.Calculate(parsedExp));*/

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


            /*string expression = Parser.GetStringsFromFile("../../../expression.txt")[0];
            Console.WriteLine(expression);
            List parsedExp = PostfixNotation.GetPostfixNotation(expression);
            parsedExp = PostfixNotation.GetListOfTokensFromPNString(Parser.GetStringsFromFile("../../../expressionRPN.txt")[0]); 
            for (int i = 0; i < parsedExp.Count; i++)
            {
                Console.Write(parsedExp[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(PostfixNotation.Calculate(parsedExp));*/

            /*Queue inst = Parser.GetFileData("C://test.txt");
            Parser.ExecuteInstractionsToQueue(inst);*/

            /*list.AddLast('a');
            list.AddLast('b');
            list.AddLast('c');
            list.AddLast('d');
            list.AddInIncreasingOrder('c');
            list.PrintToConsole();*/


            //Console.WriteLine("---------------------------------" + GetTimeOfFunctionExecuting());

            Draftsman machine = new Draftsman();
            machine.Perform();
        }

        static long GetTimeOfFunctionExecuting()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var instractions = Parser.GetFileData("C://test.txt");
            //Parser.ExecuteInstractionsToStack(instractions);
            Parser.ExecuteInstractionsToStandartStack(instractions);
            stopWatch.Stop();
            return (stopWatch.Elapsed.Ticks * Stopwatch.Frequency / 1000000) / 1000000;
        }
    }
}
