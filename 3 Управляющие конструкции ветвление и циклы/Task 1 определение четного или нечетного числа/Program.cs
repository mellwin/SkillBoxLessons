using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1.
            Console.WriteLine("Введите целове число: ");

            int N = int.Parse(Console.ReadLine());

            if (N % 2 == 0)
            {
                Console.WriteLine("Это четное число");
            }
            else
            {
                Console.WriteLine("Это нечетное число");
            }
        }
    }
}
