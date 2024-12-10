using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataContext
{
    public class PhoneContactContext : DbContext
    {
        public PhoneContactContext(DbContextOptions<PhoneContactContext> options) : base(options) { }

        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
