using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Practice3
{
    class Draftsman
    {
        public List AllCommands = new List();
        public Queue Commands = new Queue();
        public bool IsPenLowered { get; private set; } = false;
        public Draftsman()
        {
            AllCommands.AddFirst("конец");
            AllCommands.AddFirst("вправо");
            AllCommands.AddFirst("вверх");
            AllCommands.AddFirst("влево");
            AllCommands.AddFirst("вниз");
            AllCommands.AddFirst("опустить перо");
            AllCommands.AddFirst("поднять перо");
        }
        public void Perform()
        {
            Console.WriteLine("Для начала записи команд введите: начало \n" +
                                "Для окончании записи введите: конец \n" +
                                "Для получения списка команд введите: инфо \n" +
                                "Для выполнения команд введите: выполнить \n" +
                                "Для завершения программы введите: выход \n");
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (userInput == "начало")
                    Commands = RecordCommands();
                else if (userInput == "инфо")
                    PrintInformation();
                else if (userInput == "выполнить")
                    Execute(Console.WindowWidth / 4, Console.CursorTop + 10);

            } while (userInput != "выход");
            
        }
        Queue RecordCommands()
        {
            Queue output = new Queue();
            string userInput;
            do
            {
                bool isCommandCorrect;
                do
                {
                    userInput = Console.ReadLine();

                    isCommandCorrect = true;
                    if (!AllCommands.Contains(userInput))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write("Неворная команда        ");
                        Console.ReadKey(false);
                        Console.Write(new string(' ', Console.WindowWidth - 1));
                        Console.SetCursorPosition(0, Console.CursorTop);
                        isCommandCorrect = false;
                    }
                } while (!isCommandCorrect);

                output.Enqueue(userInput);
            } while (userInput != "конец");

            return output;
        }

        void Execute(int startX, int startY)
        {
            int x = startX;
            int y = startY;
            while(!Commands.IsEmpty())
            {
                string command = (string)Commands.Dequeue();
                switch (command)
                {
                    case "вправо":
                        x++;
                        break;
                    case "вверх":
                        y--;
                        break;
                    case "влево":
                        x--;
                        break;
                    case "вниз":
                        y++;
                        break;
                    case "опустить перо":
                        IsPenLowered = true;
                        break;
                    case "поднять перо":
                        IsPenLowered = false;
                        break;
                    case "конец":
                        Console.SetCursorPosition(0, Console.CursorTop + 5);
                        return;
                    default:
                        throw new Exception("Неожиданная команда");
                }

                if (x > 0 && x < Console.WindowWidth/2 - 1 && y > 0)
                {
                    Console.SetCursorPosition(x * 2, y);
                    if (IsPenLowered)
                        Console.Write("██");
                }
            }
        }

        void PrintInformation()
        {
            Console.WriteLine("Список команд:\n\tначало\n\tконец\n\tвправо\n\tвлево\n\tвверх\n\tвниз\n\tопустить перо\n\tподнять перо\n");
        }
    }
}
