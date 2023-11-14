using System;
using static System.Console;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите максимальное целое число диапозона: ");
            int n = int.Parse(ReadLine());

            Random r = new Random();
            int x = r.Next(0, n);

            while (true)
            {
                WriteLine("Введите загаданное число: ");
                string inputString = ReadLine();
                if (inputString != "")
                {
                    int _x = int.Parse(inputString);

                    if (_x == x)
                    {
                        WriteLine("Вы угадали! ");
                        break;
                    }
                    else if (_x < x)
                    {
                        WriteLine("Это число меньше загаданного ");
                        continue;
                    }
                    else if (_x > x)
                    {
                        WriteLine("Это число больше загаданного ");
                        continue;
                    }
                }
                else
                {
                    WriteLine($"Было загадано число: {n} ");
                    break;
                }
            }
        }
    }
}
