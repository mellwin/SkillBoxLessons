using System.Data.Entity;

namespace WpfApp
{
    public class AnimalContext : DbContext
    {
        public AnimalContext() : base("CodeFirst") { }

        public DbSet<Animal> Animals { get; set; }
    }
}