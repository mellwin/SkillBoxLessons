using System;

namespace Task_2
{
    class Program
    {
        public static string[] getParseText(string _text)
        {
            String[] _masText = _text.Split(new char[] { ' ' });

            return _masText;
        }

        public static string ReversWords(string _text)
        {
            string ResultString = "";
            String[] masText = getParseText(_text);

            for (int i = masText.GetLength(0) - 1; i >= 0; i--)
            {
                ResultString += masText[i] + " ";
            }

            return ResultString;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");

            string text = Console.ReadLine();

            Console.WriteLine(ReversWords(text));
            Console.ReadKey();
        }
    }
}
