namespace ModelAnimals
{
    public class Animal : IAnimal
    {
        public Guid Id { get; set; }
        public string ClassAnimal { get; set; } = null!;
        public string? Species { get; set; }
        public string? Name { get; set; }
        public string? Nutrition { get; set; }
    }
}