using System;
using System.Globalization;
using System.IO;
using System.Linq;

private const string DataFilePath = "..\\DATA.txt";
private static void CheckAndCreateDataFile()
{
    if (!File.Exists(DataFilePath))
        File.Create(DataFilePath);
}
    //создание файла если он отсутствует.
    CheckAndCreateDataFile();

    Repository repo = new Repository();

    Console.WriteLine("Введите 1 чтобы показать содержимое файла" +
                    "\nВведите 2 чтобы записать строку" +
                    "\nВведите 3 чтобы вывести работника по идентификатору" +
                    "\nВведите 4 чтобы удалить работника по идентификатору" +
                    "\nВведите 5 чтобы показать работников в промежутке времени" +
                    "\nВведите 0 для выхода");

    int funcFlag = 999;

    while (funcFlag != 0)
    {
        string readFlag = Console.ReadLine();

        funcFlag = int.Parse(readFlag == "" ? "0" : readFlag);

        if (funcFlag == 1)
        {
            Worker[] workers = repo.GetAllWorkers();
            OutputDisplay(workers);
        }

        else if (funcFlag == 2)
        {
            Worker worker = FillNewWorker();
            repo.AddWorker(worker);
        }

        else if (funcFlag == 3)
        {
            Console.WriteLine("Введите Идентификатор");
            Worker worker = repo.GetWorkerById(Convert.ToInt32(Console.ReadLine()));
            Worker[] workers = new Worker[1];
            workers[0] = worker;
            OutputDisplay(workers);
        }

        else if (funcFlag == 4)
        {
            Console.WriteLine("Введите Идентификатор");
            repo.DeleteWorker(Convert.ToInt32(Console.ReadLine()));
        }

        else if (funcFlag == 5)
        {
            Console.WriteLine("Введите дату начала в формате ДД.ММ.ГГГГ");
            DateTime dateStart = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Введите дату окончания в формате ДД.ММ.ГГГГ");
            DateTime dateEnd = Convert.ToDateTime(Console.ReadLine());

            Worker[] workers = repo.GetWorkersBetweenTwoDates(dateStart, dateEnd);
            OutputDisplay(workers);
        }

        else if (funcFlag == 0)
        {
            break;
        }
    }

public static void OutputDisplay(Worker[] workers)
{
    foreach (Worker worker in workers)
    {
        Console.WriteLine($"{worker.Id,3} {worker.DateTimeRecord,20} {worker.FIO,30} {worker.Age,8} {worker.High,8} {worker.BirthDate,20} {worker.BirthPlace,20}");
    }
}

private static Worker FillNewWorker()
{
    Worker worker = new Worker();

    worker.DateTimeRecord = DateTime.Now;

    Console.WriteLine("Введите ФИО");
    worker.FIO = Console.ReadLine();

    Console.WriteLine("Введите рост");
    worker.High = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Введите День рождения в формате ДД.ММ.ГГГГ ");
    worker.BirthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

    Console.WriteLine("Введите город проживания");
    worker.BirthPlace = Console.ReadLine();

    return worker;
}