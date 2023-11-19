using System;
using System.Collections.Generic;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAppDescription();

            var dict = FillNumbersDict();
            PrintDict(dict);

            var findedNumber = FindUserByNumber(dict);
            Console.WriteLine($"Владелец - {findedNumber}");
        }

        static string FindUserByNumber(Dictionary<string, string> input)
        {
            Console.WriteLine("Введите в программу номер телефона, чтобы найти ФИО владельца");
            input.TryGetValue(Console.ReadLine(), out string findedNumber);

            if (string.IsNullOrEmpty(findedNumber)) return "Владелец не найден";
            return findedNumber;

            Console.WriteLine($"Владелец - {findedNumber}");
        }

        static Dictionary<string, string> FillNumbersDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Введите в программу номер телефона");
                string inputNumber = Console.ReadLine();
                if (IsFinishOfFilling(inputNumber)) break;

                Console.WriteLine("Введите в программу ФИО");
                string inputFIO = Console.ReadLine();
                if (IsFinishOfFilling(inputFIO)) break;

                dict.Add(inputNumber, inputFIO);
            }

            return dict;
        }

        static void PrintDict(Dictionary<string, string> input)
        {
            foreach (KeyValuePair<string, string> e in input) Console.WriteLine($"{e} ");
        }

        static bool IsFinishOfFilling(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            return false;
        }

        static void ShowAppDescription()
        {
            Console.WriteLine("Введите в программу номера телефонов и ФИО их владельцев ");
        }
    }
}
