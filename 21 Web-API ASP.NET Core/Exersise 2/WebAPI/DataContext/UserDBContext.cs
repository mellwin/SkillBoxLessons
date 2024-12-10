using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.AuthApp;

namespace WebAPI.DataContext
{
    public class UserDBContext : IdentityDbContext<User>
    {
        public UserDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> PhoneContacts { get; set; }
    }
}