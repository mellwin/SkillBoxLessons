using System.Data.Entity;

namespace WebApp.Models
{
    public class PhoneContactContext : DbContext
    {
        public PhoneContactContext() : base("CodeFirst") { }

        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
