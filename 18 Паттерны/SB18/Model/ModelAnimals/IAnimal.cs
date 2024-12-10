namespace ModelAnimals
{
    public interface IAnimal
    {
        Guid Id { get; set; }
        string ClassAnimal { get; set; }
        string Species { get; set; }
        string Name { get; set; }
        string Nutrition { get; set; }
    }
}
