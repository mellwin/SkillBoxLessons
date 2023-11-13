using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 3.
            Console.WriteLine("Ведите число: ");

            int N = int.Parse(Console.ReadLine());
            bool prost = false;

            for (int i = 2; i < N - 1; i++) 
            {
                if (N % i == 0)
                {
                    prost = true;
                }
            };

            Console.WriteLine(prost);

        }
    }
}
