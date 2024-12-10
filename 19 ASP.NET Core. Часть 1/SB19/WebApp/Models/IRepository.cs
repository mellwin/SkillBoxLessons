namespace WebApp.Models
{
    public interface IRepository
    {
        public Task Insert(PhoneContact animal);
        public Task<List<PhoneContact>> SelectAll();
        public Task Update(PhoneContact animal);
        public Task Delete(Guid id);
        public Task<PhoneContact> Find(Guid Id);
    }
}