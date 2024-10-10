using System;
using System.IO;

namespace ConsoleApp1
{
    class Repository
    {
        private Worker[] Workers;
        private const string DataFilePath = "..\\DATA.txt";

        public Worker this[int index]
        {
            get { return Workers[index]; }
            set { Workers[index] = value; }
        }

        public Repository(params Worker[] Args)
        {
            Workers = Args;
        }

        public Worker[] GetAllWorkers()
        {   // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров

            string[] lines = File.ReadAllLines(DataFilePath);

            Worker[] workers = new Worker[0];

            for (int i = 0; i < lines.GetLength(0); i++)
            {
                Array.Resize(ref workers, workers.Length + 1);
                workers[i] = GetParseStringToWorker(lines[i]);
            }
            return workers;

        }

        public Worker GetWorkerById(int id)
        {   // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker[] workers = GetAllWorkers();

            Worker worker = new Worker();

            foreach (var pers in workers)
            {
                if (pers.Id == id)
                {
                    worker = pers;
                    break;
                };
            }

            return worker;
        }

        public void DeleteWorker(int id)
        {   // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого

            string[] lines = File.ReadAllLines(DataFilePath);

            Worker[] factWorkers = GetAllWorkers();
            Worker[] resultWorkers = new Worker[0];

            //заполняю новый массив без удаляемого элемента
            for (int i = 0; i < factWorkers.GetLength(0); i++)
            {
                if (factWorkers[i].Id != id)
                {
                    Array.Resize(ref resultWorkers, resultWorkers.Length + 1);
                    resultWorkers[i] = factWorkers[i];
                };
            }

            //переписываю файл новым массивом

            File.WriteAllLines(DataFilePath, new String[0]);

            for (int i = 0; i < resultWorkers.GetLength(0); i++)
            {
                AddWorker(resultWorkers[i]);
            }

        }

        public void AddWorker(Worker worker)
        {   // присваиваем worker уникальный ID,
            // дописываем нового worker в файл

            string[] lines = File.ReadAllLines(DataFilePath);

            worker.Id = lines.Length + 1;

            Array.Resize(ref lines, lines.Length + 1);

            string newRecord = $"{worker.Id}#{worker.DateTimeRecord}#{worker.FIO}#{worker.Age}#{worker.High}#{worker.BirthDate}#{worker.BirthPlace}";

            lines[lines.Length - 1] = newRecord;

            File.WriteAllLines(DataFilePath, lines);
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime DateTo)
        {   // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров

            Worker[] workers = GetAllWorkers();
            Worker[] workerByDate = new Worker[0]; ;

            for (int i = 0; i < workers.GetLength(0); i++)
            {
                if (workers[i].DateTimeRecord >= dateFrom && workers[i].DateTimeRecord <= DateTo)
                {
                    Array.Resize(ref workerByDate, workerByDate.Length + 1);
                    workerByDate[i] = workers[i];
                };
            }

            return workers;
        }

        public static Worker GetParseStringToWorker(string line)
        {
            char sym = '#';
            String[] _masText = line.Split(new char[] { sym });

            return new Worker(Convert.ToInt32(_masText[0]),
                              Convert.ToDateTime(_masText[1]),
                              _masText[2],
                              Convert.ToInt32(_masText[3]),
                              Convert.ToDouble(_masText[4]),
                              Convert.ToDateTime(_masText[5]),
                              _masText[6]);
        }
    }
}
