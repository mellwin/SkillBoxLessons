namespace WpfApp
{
    public class NullAnimal : IAnimal
    {
        public Guid Id { get; set; }

        public string ClassAnimal { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public string Nutrition { get; set; }

        public NullAnimal()
        {
            Id = Guid.NewGuid();
            ClassAnimal = "Not Determined";
            Species = "Not Determined";
            Name = "Not Determined";
            Nutrition = "Not Determined";
        }
    }
}
