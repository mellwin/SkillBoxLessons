using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 2.
            Console.WriteLine("Сколько карт на руках?");

            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Введите номинал {i} карты: ");

                string nominal = Console.ReadLine();
                switch (nominal)
                {
                    case "j": sum += 10; break;
                    case "q": sum += 10; break;
                    case "k": sum += 10; break;
                    case "t": sum += 10; break;
                    case "2": sum += 2; break;
                    case "3": sum += 3; break;
                    case "4": sum += 4; break;
                    case "5": sum += 5; break;
                    case "6": sum += 6; break;
                    case "7": sum += 7; break;
                    case "8": sum += 8; break;
                    case "9": sum += 9; break;
                    case "10": sum += 10; break;

                }
            };

            Console.WriteLine($"Сумма карт: {sum}");
        }
    }
}
