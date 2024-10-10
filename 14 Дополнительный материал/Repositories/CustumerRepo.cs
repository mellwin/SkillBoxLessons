using SB14.Models;

namespace SB14.Repositories
{
    class CustumerRepo : Repository<Custumer>, IRepository<Custumer>
    {
        public static event Action<string> CustumerCreatedNotification;

        public CustumerRepo() : base() { }
        public void Insert(Custumer inputInstance)
        {
            var custumerList = SelectAllDataFromJsonFile();

            if (custumerList.Count() == 0)
            {
                inputInstance.Id = 1;
            }
            else
            {
                inputInstance.Id = custumerList.Max(c => c.Id) + 1;
            }

            custumerList.Add(inputInstance);

            SerializeAndWriteToJsonFile(custumerList);
            CustumerCreatedNotification?.Invoke($"Создан новый клиент: {inputInstance.Name}");
        }

        public void Delete(int id)
        {
            var custumerList = SelectAllDataFromJsonFile();

            foreach (var c in custumerList)
            {
                if (c.Id == id) custumerList.Remove(c);
            }

            SerializeAndWriteToJsonFile(custumerList);
        }

        public void Update(Custumer custumer)
        {
            var custumerList = SelectAllDataFromJsonFile();

            foreach (var c in custumerList)
            {
                if (c.Id == custumer.Id)
                {
                    c.Name = custumer.Name;
                }
            }

            SerializeAndWriteToJsonFile(custumerList);
        }

        public Custumer Find(int id)
        {
            var custumerList = SelectAllDataFromJsonFile();
            var custumer = new Custumer();

            foreach (var c in custumerList)
            {
                if (c.Id == id)
                {
                    custumer = c;
                    break;
                }
            }

            return custumer;
        }
    }
}
