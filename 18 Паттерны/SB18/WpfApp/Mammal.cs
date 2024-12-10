namespace WpfApp
{
    public class Mammal : IAnimal
    {
        public Guid Id { get; set; }

        public string ClassAnimal { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Nutrition { get; set; }

        public Mammal(Guid id, string classAnimal, string name, string species, string nutrition)
        {
            Id = id;
            ClassAnimal = classAnimal;
            Name = name;
            Species = species;
            Nutrition = nutrition;
        }

        public Mammal(string classAnimal, string name, string species, string nutrition)
        {
            Id = Guid.NewGuid();
            ClassAnimal = classAnimal;
            Name = name;
            Species = species;
            Nutrition = nutrition;
        }
    }
}
