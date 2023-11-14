using System;
using static System.Console;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите длину последовательности: ");
            int n = int.Parse(ReadLine());

            var Array = new int[n];
            int MinValue = int.MaxValue;

            WriteLine("Последовательно введите целые числа: ");

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                Array[i] = int.Parse(ReadLine());
                if (MinValue > Array[i])
                {
                    MinValue = Array[i];
                }
            }

            WriteLine();

            WriteLine($"Минимальное число: {MinValue}");

        }
    }
}
