namespace SB13.Models
{
    public class Custumer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        Custumer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Custumer(string name)
        {
            Name = name;
        }

        public Custumer() { }
    }
}
