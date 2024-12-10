namespace DAL
{
    public interface IRepository<T>
    {
        public void Insert(T inputInstance);
        public void Delete(int id);
        public void Update(T inputInstance);
        public T Find(int id);
    }
}
