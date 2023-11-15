using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        private const string DataFilePath = "..\\DATA.txt";
        private static void CheckAndCreateDataFile()
        {
            if (!File.Exists(DataFilePath))
                File.Create(DataFilePath);

        }

        public static string[] GetParseText(string _text)
        {//возвращает массив слов из строки
            char sym = '#';
            String[] _masText = _text.Split(new char[] { sym });

            return _masText;
        }

        public static void OutputDisplay()
        {//вывод строк на экран
            string[] lines = File.ReadAllLines(DataFilePath);

            foreach (var Line in lines)
            {
                string[] text = GetParseText(Line);

                for (int i = 0; i < text.GetLength(0); i++)
                {
                    Console.Write(text[i] + " ");
                }
                Console.WriteLine();
            };
        }


        public static void AddRecord()
        {//Добавление записи в файл
            string[] lines = File.ReadAllLines(DataFilePath);
            Worker worker = FillWorker(lines);

            Array.Resize(ref lines, lines.Length + 1);

            string newRecord = $"{worker.Id}#{worker.DateTimeRecord}#{worker.FIO}#{worker.Age}#{worker.High}#{worker.BirthDate}#{worker.BirthPlace}";

            lines[lines.Length - 1] = newRecord;

            File.WriteAllLines(DataFilePath, lines);
        }

        private static Worker FillWorker(string[] lines)
        {
            Worker worker = new Worker();

            worker.Id = lines.Length + 1;

            worker.DateTimeRecord = DateTime.Now;

            Console.WriteLine("Введите ФИО");
            worker.FIO = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            worker.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите рост");
            worker.High = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите День рождения в формате ДД.ММ.ГГГГ ");
            worker.BirthDate = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Введите город проживания");
            worker.BirthPlace = Console.ReadLine();


            return worker;
        }

        public static void EditRecord()
        {

        }

        public static Worker GetWorkerById(int Id)
        {
            return new Worker();
        }

        static void Main(string[] args)
        {
            //создание файла если он отсутствует.
            CheckAndCreateDataFile();

            Console.WriteLine("Введите 1 чтобы показать содержимое файла" +
                            "\nВведите 2 чтобы записать строку" +
                            "\nВведите 3 чтобы изменить строку" +
                            "\nВведите 0 для выхода");

            int funcFlag = 999;

            while (funcFlag != 0)
            {
                string readFlag = Console.ReadLine();

                funcFlag = int.Parse(readFlag == "" ? "0" : readFlag);

                if (funcFlag == 1)
                {
                    OutputDisplay();
                }
                else if (funcFlag == 2)
                {
                    AddRecord();
                }
                else if (funcFlag == 3)
                {
                    EditRecord();
                }
                else if (funcFlag == 0)
                {
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}
