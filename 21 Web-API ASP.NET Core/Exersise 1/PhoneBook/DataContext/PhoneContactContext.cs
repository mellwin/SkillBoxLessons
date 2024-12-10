using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DataContext
{
    public class PhoneContactContext : DbContext
    {
        public PhoneContactContext(DbContextOptions<PhoneContactContext> options) : base(options) { }

        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
