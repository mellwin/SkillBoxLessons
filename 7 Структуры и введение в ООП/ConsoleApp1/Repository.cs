using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Repository
    {
        private Worker[] Workers;

        public Worker this[int index]
        {
            get { return Workers[index]; }
            set { Workers[index] = value; }
        }

        public Worker[] GetAllWorkers() 
        {   // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
            return Workers;
        
        }

        public Worker GetWorkerById(int id)
        {   // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker worker = new Worker();
            return worker;
        }

        public void DeleteWorker(int id)
        {   // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого

        }

        public void AddWorker(Worker worker)
        {   // присваиваем worker уникальный ID,
            // дописываем нового worker в файл

        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime DateTo)
        {   // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
            return Workers;
        }
    }
}
