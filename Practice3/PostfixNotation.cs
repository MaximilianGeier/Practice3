using System;
using System.Text;

namespace Practice3
{
    static class PostfixNotation
    {
        static readonly List signsList = new List();
        static PostfixNotation()
        {
            signsList.AddLast("+");
            signsList.AddLast("-");
            signsList.AddLast("*");
            signsList.AddLast(":");
            signsList.AddLast("/");
            signsList.AddLast("^");
            signsList.AddLast("(");
            signsList.AddLast(")");
            signsList.AddLast("sin");
            signsList.AddLast("log");
            signsList.AddLast("ln");
            signsList.AddLast("sqrt");
            signsList.AddLast("round");
        }
        
        static int GetPriority(string operation)
        {
            switch (operation)
            {
                case "(":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case ":":
                case "/":
                    return 2;
                case "^":
                    return 3;
                case "sin":
                case "log":
                case "ln":
                case "sqrt":
                case "round":
                    return 10;
                default:
                    throw new Exception("Несуществующая операция");
            }
        }

        static public List GetPostfixNotation(string input)
        {
            List pInput = GetListOfTokens(input);
            List firstList = new List();
            List secondList = new List();
            bool isDebugEnabled = false;

            for (int i = 0; i < pInput.Count; i++)
            {
                if (Char.IsDigit(((string)pInput[i])[0])) firstList.AddLast(pInput[i]);
                else
                if (((string)pInput[i])[0] == '(') secondList.AddLast(pInput[i]);
                else
                if (((string)pInput[i])[0] == ')')
                {
                    for (int ii = secondList.Count - 1; ii >= 0; ii--)
                    {
                        if (secondList[ii].Equals("("))
                        {
                            secondList.RemoveAt(secondList.Count - 1);
                            break;
                        }
                        else
                        {
                            firstList.AddLast(secondList[secondList.Count - 1]);
                            secondList.RemoveAt(secondList.Count - 1);
                        }
                    }
                }
                else
                if (signsList.Contains(pInput[i]))
                {
                    if (secondList.Count >= 1)
                    {
                        if (GetPriority((string)secondList[secondList.Count - 1]) >= GetPriority((string)pInput[i]))
                        {
                            firstList.AddLast(secondList[secondList.Count - 1]);
                            secondList.RemoveAt(secondList.Count - 1);
                        }
                    }
                    secondList.AddLast(pInput[i]);
                }

                if (isDebugEnabled)
                {
                    for (int ii = 0; ii < pInput.Count; ii++)
                    {
                        if (ii == i) Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(pInput[ii] + " ");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    string local = "";
                    for (int ii = 0; ii < firstList.Count; ii++) local += firstList[ii] + " ";
                    Console.WriteLine("Первая строка: " + local);
                    local = "";
                    for (int ii = 0; ii < secondList.Count; ii++) local += secondList[ii] + " ";
                    Console.WriteLine("Вторая строка: " + local);

                    Console.ReadKey(true);
                    Console.Clear();
                }
            }

            for (int i = secondList.Count - 1; i >= 0; i--) firstList.AddLast(secondList[i]);

            return firstList;
        }

        //Выделить в строке цифры и знаки
        static List GetListOfTokens(string input)
        {
            List preOutput = new List();
            List output;
            input += "  ";

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    preOutput.AddLast("");
                    for (; i < input.Length; i++)
                    {
                        if (Char.IsDigit(input[i]) || input[i] == '.')
                        {
                            preOutput[^1] = (string)preOutput.GetLast() + input[i];
                        }
                        else
                        {
                            if (input[i] == 'E' && (input[i + 1] == '+' || input[i + 1] == '-'))
                            {
                                preOutput[^1] = (string)preOutput.GetLast() + input[i];
                                preOutput[^1] = (string)preOutput.GetLast() + input[i + 1];
                                i++;
                            }
                            else
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
                else if (signsList.Contains(Convert.ToString(input[i])))
                {
                    if (input[i] == '-')
                        if (i > 0)
                        {
                            if (!Char.IsDigit(input[i - 1]) && (input[i - 1] == '(' || input[i - 1] != ')'))
                                preOutput.AddLast("0");
                        }
                        else
                        {
                            preOutput.AddLast("0");
                        }
                    preOutput.AddLast(Convert.ToString(input[i]));
                }
                else if (input[i] != ' ' && input[i] != ',' && input[i] != ';')
                {
                    string local = "";
                    for (; ; i++)
                    {
                        local += input[i];
                        if (signsList.Contains(Convert.ToString(local))) 
                            break;
                    }
                    preOutput.AddLast(local);
                }
            }

            output = new List();
            for (int i = 0; i < preOutput.Count; i++) 
                output.AddLast(preOutput[i]);

            return output;
        }

        public static List GetListOfTokensFromPNString(string data)
        {
            List output = new List();
            data = data.Replace("  ", " ");
            string temp = string.Empty;
            foreach (var c in data)
            {
                if (c == ' ')
                {
                    output.AddLast(temp);
                    temp = string.Empty;
                }
                else
                {
                    temp += c;
                }
            }
            if (temp.Length > 0)
                output.AddLast(temp);

            return output;
        }

        static public double Calculate(List input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (!IsStringDigit((string)input[i]))
                {
                    switch (input[i])
                    {
                        case "+":
                            input[i] = Convert.ToString(Convert.ToDouble(input[i - 2]) + Convert.ToDouble(input[i - 1]));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case "-":
                            input[i] = Convert.ToString(Convert.ToDouble(input[i - 2]) - Convert.ToDouble(input[i - 1]));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case "*":
                            input[i] = Convert.ToString(Convert.ToDouble(input[i - 2]) * Convert.ToDouble(input[i - 1]));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case ":":
                        case "/":
                            input[i] = Convert.ToString(Convert.ToDouble(input[i - 2]) / Convert.ToDouble(input[i - 1]));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case "^":
                            input[i] = Convert.ToString(Math.Pow(Convert.ToDouble(input[i - 2]), Convert.ToDouble(input[i - 1])));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case "sin":
                            input[i] = Convert.ToString(Math.Sin(Convert.ToDouble(input[i - 1])));
                            input.RemoveAt(i - 1);
                            i -= 1;
                            break;
                        case "log":
                            input[i] = Convert.ToString(Math.Log10(Convert.ToDouble(input[i - 2])) / Math.Log10(Convert.ToDouble(input[i - 1])));
                            input.RemoveAt(i - 1);
                            input.RemoveAt(i - 2);
                            i -= 2;
                            break;
                        case "ln":
                            input[i] = Convert.ToString(Math.Log10(Convert.ToDouble(input[i - 1]))/ Math.Log10(Math.E));
                            input.RemoveAt(i - 1);
                            i -= 1;
                            break;
                        case "sqrt":
                            input[i] = Convert.ToString(Math.Sqrt(Convert.ToDouble(input[i - 1])));
                            input.RemoveAt(i - 1);
                            i -= 1;
                            break;
                        case "round":
                            input[i] = Convert.ToString(Math.Round(Convert.ToDouble(input[i - 1])));
                            input.RemoveAt(i - 1);
                            i -= 1;
                            break;
                        default:
                            throw new Exception("Неожиданная операция");
                    }
                }
            }

            return Convert.ToDouble(input[0]);

            bool IsStringDigit(string input)
            {
                return Char.IsDigit(input[0]) || (input.Length > 1 && Char.IsDigit(input[1]));
            }
        }
    }
}
