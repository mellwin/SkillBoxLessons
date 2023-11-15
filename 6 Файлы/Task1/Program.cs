using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static string[] getParseText(string _text, char sym)
        {//возвращает массив слов из строки
            String[] _masText = _text.Split(new char[] {sym});

            return _masText;
        }

        public static bool CheckFile(string _path)
        {//проверка на наличие файла

            return File.Exists(_path);
        }

        public static void OutputDisplay(string[] _lines)
        {//вывод строк на экран
            foreach (var Line in _lines)
            {
                string[] text = getParseText(Line, '#');

                for (int i = 0; i < text.GetLength(0); i++)
                {
                    Console.WriteLine(text[i]);
                }
            };
        }

        public static string[] AddLine(string[] _lines, string _path)
        {//Добавление записи в файл
            Console.WriteLine("Введите номую запись");

            string newLine = Console.ReadLine();

            string[] newLines = new string[_lines.Length + 1];

            for (int i = 0; i < _lines.GetLength(0); i++)
            {
                for (int j = 0; j < newLines.GetLength(0); j++)
                {
                    newLines[j] = _lines[i];
                }
            }

            newLines[^1] = newLine;

            File.WriteAllLines(_path, newLines);
            
            return _lines;
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\oapar\OneDrive\Documents\GitHub\SkillBox\6 Файлы\Task1\Сотрудники.txt";

            //создание файла если он отсутствует.
            if (CheckFile(path) == false)
            {
                File.WriteAllText(path, "");
            }
            Console.WriteLine(@"Введите 1 чтобы показать содержимое файла \nВведите 2 чтобы записать строку");

            int funcFlag = int.Parse(Console.ReadLine());

            string[] lines = File.ReadAllLines(path);

            if (funcFlag == 1)
            {
                OutputDisplay(lines);
                Console.ReadKey();
            }
            else if (funcFlag == 2)
            {
                AddLine(lines, path);
                Console.ReadKey();
            }
        }
    }
}
