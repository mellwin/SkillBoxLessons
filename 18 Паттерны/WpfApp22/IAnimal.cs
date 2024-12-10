namespace Exercise1
{
    public interface IAnimal
    {
        Guid Id { get; }
        string Name { get; }
        string Species { get; }
        string Nutrition { get; }
    }
}
