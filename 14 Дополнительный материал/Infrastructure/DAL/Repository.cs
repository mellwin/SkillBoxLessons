using System.Text.Json;

namespace DAL
{
    public abstract class Repository<T>
    {
        protected readonly string path = $"{typeof(T)}.json";

        public Repository()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");

        }

        protected void SerializeAndWriteToJsonFile(List<T> list)
        {
            string newJson = JsonSerializer.Serialize(list);

            File.WriteAllText(path, newJson);
        }

        public List<T> SelectAllDataFromJsonFile()
        {
            if (!File.Exists(path)) return new List<T>();

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json)) return new List<T>();
            else return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

        }
    }
}