using System;
//using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Practice3
{
    public static class Parser
    {
        public static Queue GetFileData(string path)
        {
            Queue instruction = new Queue();
            string data = File.ReadAllText(path);
            data = data.Replace("  ", " ");
            string temp = string.Empty;
            foreach (var c in data)
            {
                if (c != ' ')
                {
                    temp += c;
                }
                else
                {
                    instruction.Enqueue(temp);
                    temp = string.Empty;
                }
            }
            if (temp.Length > 0)
                instruction.Enqueue(temp);

            return instruction;
        }

        public static void ExecuteInstractions(Queue instractions)
        {
            Stack stack = new Stack();
            while(instractions.Peek() != null)
            {
                string temp = (string)instractions.Dequeue();
                switch (temp)
                {
                    case "2":
                        Console.WriteLine(stack.Pop());
                        break;
                    case "3":
                        Console.WriteLine(stack.Top());
                        break;
                    case "4":
                        Console.WriteLine(stack.isEmpty());
                        break;
                    case "5":
                        stack.Print();
                        Console.WriteLine();
                        break;
                    default:
                        if (temp[0] == '1')
                        {
                            stack.Push(temp.Substring(2));
                            Console.WriteLine(stack.Top());
                        }
                        break;
                }
            }
        }
    }
}
