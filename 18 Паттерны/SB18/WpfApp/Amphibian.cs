namespace WpfApp
{
    public class Amphibian : IAnimal
    {
        public Guid Id { get; set; }

        public string ClassAnimal { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Nutrition { get; set; }

        public Amphibian(Guid id, string classAnimal, string name, string species, string nutrition)
        {
            Id = id;
            ClassAnimal = classAnimal;
            Name = name;
            Species = species;
            Nutrition = nutrition;
        }

        public Amphibian(string classAnimal, string name, string species, string nutrition)
        {
            Id = Guid.NewGuid();
            ClassAnimal = classAnimal;
            Name = name;
            Species = species;
            Nutrition = nutrition;
        }

    }
}
