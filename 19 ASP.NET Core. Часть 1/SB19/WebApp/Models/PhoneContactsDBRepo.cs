using System.Data;
using System.Data.Entity;

namespace WebApp.Models
{
    public class PhoneContactsDBRepo : IRepository
    {
        public async Task<List<PhoneContact>> SelectAll()
        {

            using (var db = new PhoneContactContext())
            {
                var animals = await db.PhoneContacts.ToListAsync();
                return animals.Select(animal => (PhoneContact)animal).ToList();
            }
        }

        public async Task Insert(PhoneContact phoneContact)
        {
            var newAnimal = new PhoneContact() { Id = Guid.NewGuid(), Name = phoneContact.Name, PhoneNumber = phoneContact.PhoneNumber, Address = phoneContact.Address, Descriptions = phoneContact.Descriptions };
            using (var db = new PhoneContactContext())
            {
                db.PhoneContacts.Add(newAnimal);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(PhoneContact phoneContact)
        {
            using (var db = new PhoneContactContext())
            {
                var currentPhoneContact = await db.PhoneContacts.Where(c => c.Id == phoneContact.Id).FirstAsync();
                if (currentPhoneContact != null)
                {
                    currentPhoneContact.Id = phoneContact.Id;
                    currentPhoneContact.Name = phoneContact.Name;
                    currentPhoneContact.PhoneNumber = phoneContact.PhoneNumber;
                    currentPhoneContact.Address = phoneContact.Address;
                    currentPhoneContact.Descriptions = phoneContact.Descriptions;

                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task Delete(Guid id)
        {
            using (var db = new PhoneContactContext())
            {
                db.PhoneContacts.Remove(await db.PhoneContacts.Where(c => c.Id == id).FirstAsync());
                await db.SaveChangesAsync();
            }
        }

        public async Task<PhoneContact> Find(Guid Id)
        {
            using (var db = new PhoneContactContext())
            {
                return db.PhoneContacts.Where(c => c.Id == Id).FirstAsync().Result;
            }
        }
    }
}
