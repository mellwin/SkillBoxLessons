namespace ModelAnimals
{
    public interface IRepository
    {
        public Task Insert(IAnimal animal);
        public Task<List<IAnimal>> SelectAll();
        public Task Update(IAnimal animal);
        public Task Delete(Guid id);
    }
}