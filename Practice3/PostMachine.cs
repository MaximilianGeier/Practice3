using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Practice3
{
    class PostMachine
    {
        public List AllCommands = new List();
        public List Commands;
        private List field = new List();
        private readonly int maxPos = Console.WindowWidth / 2 - 2;
        private int indent = 0;
        public int CarriagePos { get; private set; }
        public PostMachine()
        {
            AllCommands.AddLast('R');
            AllCommands.AddLast('L');
            AllCommands.AddLast('I');
            AllCommands.AddLast('?');
            AllCommands.AddLast('!');
        }
        public void Perform()
        {
            Console.WriteLine("Список команд: \n\tR - сдвинуть коретку вправо" +
                "\n\tL - сдвинуть коретку влево" +
                "\n\tI - инвертировать метку" +
                "\n\t! - закончить программу" +
                "\n\t?<a>;<b> - если под коректрой нет метки, то перейти к коменде строке, иначе к строке b\n");
            Console.WriteLine("Строка с командой имет вид: <номер строки>. <команда><следующая строка>");
            Console.WriteLine("Введите код (для завершения ввода введите \"end\"):\n");

            Commands = GetCommandList();
            EnterField();
            Execute();
            Console.SetCursorPosition(0, Console.CursorTop + 5);
        }

        List GetCommandList()
        {
            List output = new List();
            string userInput;
            int strNum = 1;
            do
            {
                bool next;
                do
                {
                    Console.Write(strNum + ". ");
                    userInput = Console.ReadLine();
                    if (userInput.Length == 3 && userInput.Contains("end"))
                    {
                        return output;
                    }
                    else
                    {
                        next = false;
                        if (!IsLineCorrect(userInput, out string errorText))
                        {
                            next = true;
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write('\r' + errorText);
                            Console.ReadKey(false);
                            Console.Write(new string(' ', Console.WindowWidth - 1) + "\r");
                        }
                    }
                } while (next);

                output.AddLast(userInput);
                strNum++;
            } while (true);
        }

        void EnterField()
        {
            Console.WriteLine("\nЗаполните поле (стрелочки передвигают коретку, space инвертирует ячейку, enter - запустить программу)\n");

            for (int i = 0; i <= maxPos; i++)
            {
                field.AddLast(false);
            }
            do
            {
                DrawCarriage();
                ConsoleKeyInfo key = Console.ReadKey(false);
                if (key.Key == ConsoleKey.RightArrow && CarriagePos < maxPos)
                {
                    EraseCarrige();
                    CarriagePos++;
                }
                else if (key.Key == ConsoleKey.LeftArrow && CarriagePos > 0)
                {
                    EraseCarrige();
                    CarriagePos--;
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    InvertMark();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return;
                }
            } while (true);
        }
        void DrawCarriage()
        {
            int pos = CarriagePos - indent;
            if (pos >= 0 && pos <= maxPos)
            {
                Console.SetCursorPosition(pos * 2, Console.CursorTop);
                Console.Write(@"\/");
            }
        }
        void EraseCarrige()
        {
            int pos = CarriagePos - indent;
            if (pos >= 0 && pos <= maxPos)
            {
                Console.SetCursorPosition(pos * 2, Console.CursorTop);
                Console.Write("  ");
            }
        }
        void Execute()
        {
            int iterationNum = 0;
            int i = 1;
            do
            {
                string command = (string)Commands[i-1];
                switch (command[0])
                {
                    case 'R':
                        EraseCarrige();
                        CarriagePos++;
                        if (CarriagePos > field.Count)
                            field.AddLast(false);
                        i = int.Parse(command.Substring(1));
                        DrawCarriage();
                        break;
                    case 'L':
                        EraseCarrige();
                        CarriagePos--;
                        if (CarriagePos == -1)
                        {
                            field.AddFirst(false);
                            CarriagePos = 0;
                            indent++;
                        }
                        DrawCarriage();
                        i = int.Parse(command.Substring(1));
                        break;
                    case 'I':
                        InvertMark();
                        i = int.Parse(command.Substring(1));
                        break;
                    case '?':
                        i = GetNextStrNumInCondition(command);
                        break;
                    case '!':
                        return;
                    default:
                        throw new Exception("Неожиданная команда");
                }
                iterationNum++;
            } while(iterationNum < 100000);

            Console.SetCursorPosition(0, Console.CursorTop + 2);
            Console.WriteLine("Каретка зациклилась");

            int GetNextStrNumInCondition(string condition)
            {
                string output = string.Empty;
                if (!(bool)field[CarriagePos])
                {
                    for (int i = 1; condition[i] != ';'; i++)
                    {
                        output += condition[i];
                    }
                }
                else
                {
                    int pos = 2;
                    for (int i = 1; condition[i] != ';'; i++)
                    {
                        pos++;
                    }
                    output = condition.Substring(pos);
                }
                return int.Parse(output);
            }
        }

        void InvertMark()
        {
            field[CarriagePos] = !((bool)field[CarriagePos]);
            int pos = CarriagePos - indent;
            if (pos >= 0 && pos < maxPos)
            {
                Console.SetCursorPosition(pos * 2, Console.CursorTop + 1);

                if ((bool)field[pos])
                    Console.Write("██");
                else
                    Console.Write("  ");

                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
        bool IsLineCorrect(string str, out string errorText)
        {
            errorText = "Ошибка отсудствует";

            if (str.Length == 0)
            {
                errorText = "Пустая строка";
                return false;
            }
            if (str.Length < 2 && str[0] != '!')
            {
                errorText = "Отсудствует часть комманды";
                return false;
            }
            if (!AllCommands.Contains(str[0]) || (str[0] == '?' && !str.Contains(';')))
            {
                errorText = "Неверная команда";
                return false;
            }
            if (str[0] != '!' && str[0] != '?' && !int.TryParse(str.Substring(1), out int result))
            {
                errorText = "Число некорректно";
                return false;
            }

            return true;
        }
    }
}
