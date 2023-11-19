using System;
using System.Collections.Generic;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = CreateRandomList();

            PrintList(list);

            RemoveNotValidFromList(list);

            PrintList(list);
        }

        static void PrintList(List<int> input)
        {
            for (int i = 0; i <= input.Count - 1; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static List<int> CreateRandomList()
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i <= 100; i++)
            {
                list.Add(rand.Next(0, 100));
            }
            return list;
        }

        static void RemoveNotValidFromList(List<int> input)
        {
            for (int i = 0; i <= input.Count - 1; i++)
            {
                if (IsValid(input[i])) input.Remove(input[i]);
            }
        }

        static bool IsValid(int input)
        {
            if (input > 25 && input < 50) return true;
            return false;
        }
    }
}
