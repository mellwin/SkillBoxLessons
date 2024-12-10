using System.Data;
using System.Data.Entity;

namespace ModelAnimals
{
    public class AnimalDBRepo : IRepository
    {
        public async Task<List<IAnimal>> SelectAll()
        {

            using (var db = new AnimalContext())
            {
                var animals = await db.Animals.ToListAsync();
                return animals.Select(animal => (IAnimal)animal).ToList();
            }
        }

        public async Task Insert(IAnimal animal)
        {
            var newAnimal = new Animal() { Id = Guid.NewGuid(), ClassAnimal = animal.ClassAnimal, Name = animal.Name, Species = animal.Species, Nutrition = animal.Nutrition };
            using (var db = new AnimalContext())
            {
                db.Animals.Add(newAnimal);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(IAnimal animal)
        {
            using (var db = new AnimalContext())
            {
                var currentAnimal = await db.Animals.Where(c => c.Id == animal.Id).FirstAsync();
                if (currentAnimal != null)
                {
                    currentAnimal.Id = animal.Id;
                    currentAnimal.ClassAnimal = animal.ClassAnimal;
                    currentAnimal.Name = animal.Name;
                    currentAnimal.Species = animal.Species;
                    currentAnimal.Nutrition = animal.Nutrition;

                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task Delete(Guid id)
        {
            using (var db = new AnimalContext())
            {
                db.Animals.Remove(await db.Animals.Where(c => c.Id == id).FirstAsync());
                await db.SaveChangesAsync();
            }
        }

        public async Task<IAnimal> Find(Guid Id)
        {
            using (var db = new AnimalContext())
            {
                return db.Animals.Where(c => c.Id == Id).FirstAsync().Result;
            }
        }
    }
}
