using System;

namespace Task_1
{
    class Program
    {
        public static string[] getParseText(string _text)
        {
            String[] _masText = _text.Split(new char[] { ' ' });

            return _masText;
        }

        static void printText(string[] _masText)
        {
            for (int i = 0; i < _masText.GetLength(0); i++)
            {
                Console.WriteLine(_masText[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");

            string text = Console.ReadLine();

            string[] masText = getParseText(text);

            printText(masText);
        }
    }
}
