using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook.AuthApp;

namespace PhoneBook.DataContext
{
    public class UserDBContext : IdentityDbContext<User>
    {
        public UserDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> PhoneContacts { get; set; }
    }
}