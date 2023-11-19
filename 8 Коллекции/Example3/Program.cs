using System;
using System.Collections.Generic;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = FillNumbersSet();

            PrintSet(set);
        }

        private static void PrintSet(HashSet<int> input)
        {
            foreach (var e in input) Console.Write($"{e} ");
        }

        static HashSet<int> FillNumbersSet()
        {
            HashSet<int> set = new HashSet<int>();

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Введите натуральное число");
                string inputNumber = Console.ReadLine();

                if (IsFinishOfFilling(inputNumber)) break;

                if (IsRepeat(set, Convert.ToInt32(inputNumber)))
                {
                    Console.WriteLine("Такое число уже есть");
                    continue;
                }

                set.Add(Convert.ToInt32(inputNumber));
            }

            return set;
        }

        static bool IsRepeat(HashSet<int> inputSet, int inputNum)
        {
            if (inputSet.Contains(inputNum)) return true;
            return false;
        }


        static bool IsFinishOfFilling(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            return false;
        }
    }
}
