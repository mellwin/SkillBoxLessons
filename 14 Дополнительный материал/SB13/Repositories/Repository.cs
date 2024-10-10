using Newtonsoft.Json;
using System.IO;

namespace SB13.Repositories
{
    internal abstract class Repository<T>
    {
        protected readonly string path = $"{typeof(T)}.json";

        public Repository()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "{}");

        }

        protected void SerializeAndWriteToJsonFile(List<T> list)
        {
            string newJson = JsonConvert.SerializeObject(list);

            File.WriteAllText(path, newJson);
        }

        public List<T> SelectAllDataFromJsonFile()
        {
            if (!File.Exists(path)) return new List<T>();

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
    }
}