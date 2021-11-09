using System;
//using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;

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
                else if(temp.Length != 0)
                {
                    instruction.Enqueue(temp);
                    temp = string.Empty;
                }
            }
            if (temp.Length > 0)
                instruction.Enqueue(temp);
            Console.WriteLine("число: " + instruction.Count);
            return instruction;
        }

        public static void ExecuteInstractionsToStack(Queue instractions)
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
                        Console.WriteLine(stack.IsEmpty());
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
        public static void ExecuteInstractionsToStandartStack(Queue instractions)
        {
            Stack<object> stack = new Stack<object>();
            while (instractions.Peek() != null)
            {
                string temp = (string)instractions.Dequeue();
                switch (temp)
                {
                    case "2":
                        Console.WriteLine(stack.Pop());
                        break;
                    case "3":
                        if(stack.Count != 0)
                            Console.WriteLine(stack.Peek());
                        break;
                    case "4":
                        Console.WriteLine(stack.Count == 0);
                        break;
                    case "5":
                        while(stack.Count != 0)
                        {
                            Console.WriteLine(stack.Pop());
                        }
                        break;
                    default:
                        if (temp[0] == '1')
                        {
                            stack.Push(temp.Substring(2));
                            Console.WriteLine(stack.Peek());
                        }
                        break;
                }
            }
        }

        public static string[] GetStringsFromFile(string path)
        {
            string[] output = new string[4];
            int i = 0;
            foreach (string element in File.ReadLines(path))
            {
                output[i] = element;
                i++;
            }

            return output;
        }
        public static void ExecuteInstractionsToQueue(Queue instractions)
        {
            Queue q = new Queue();
            while(instractions.Peek() != null)
            {
                string temp = (string)instractions.Dequeue();
                switch(temp)
                {
                    case "2":
                        Console.WriteLine(q.Dequeue());
                        break;
                    case "3":
                        Console.WriteLine(q.Peek());
                        break;
                    case "4":
                        Console.WriteLine(q.IsEmpty());
                        break;
                    case "5":
                        q.Print();
                        break;
                    default:
                        if (temp[0] == '1')
                        {
                            q.Enqueue(temp.Substring(2));
                            Console.WriteLine(q.Peek());
                        }
                        break;
                }
            }
        }

        public static void ExecuteInstractionsToStandartQueue(Queue instractions)
        {
            Queue<object> q = new Queue<object>();
            while (instractions.Peek() != null)
            {
                string temp = (string)instractions.Dequeue();
                switch (temp)
                {
                    case "2":
                        if(q.Count != 0)
                            Console.WriteLine(q.Dequeue());
                        break;
                    case "3":
                        Console.WriteLine(q.Peek());
                        break;
                    case "4":
                        Console.WriteLine(q.Count == 0);
                        break;
                    case "5":
                        while(q.Count != 0)
                        {
                            Console.WriteLine(q.Dequeue());
                        }
                        break;
                    default:
                        if (temp[0] == '1')
                        {
                            q.Enqueue(temp.Substring(2));
                            Console.WriteLine(q.Peek());
                        }
                        break;
                }
            }
        }
    }
}
