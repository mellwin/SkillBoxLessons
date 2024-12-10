using System.Data.Entity;

namespace ModelAnimals
{
    public class AnimalContext : DbContext
    {
        public AnimalContext() : base("CodeFirst") { }

        public DbSet<Animal> Animals { get; set; }
    }
}