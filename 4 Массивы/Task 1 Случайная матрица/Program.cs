using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи количество строк: ");
            int strok = int.Parse(Console.ReadLine());

            Console.WriteLine("Введи количество столбцов: ");
            int stolb = int.Parse(Console.ReadLine());

            var array = new int[strok, stolb];
            Random r = new Random();
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(1, 10);
                    Console.Write($"{array[i, j]}");
                }
                Console.WriteLine();
            };

            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    sum += array[i, j];
                }
                Console.WriteLine();

            };
            Console.WriteLine();
            Console.WriteLine(sum);


        }
    }
}