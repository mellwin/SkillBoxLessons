using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using System.Data;

namespace WebAPI.Models
{
    public class PhoneContactsDBRepo : IRepository
    {
        private readonly PhoneContactContext _context;

        public PhoneContactsDBRepo(PhoneContactContext context)
        {
            _context = context;
        }

        public async Task<List<PhoneContact>> SelectAll()
        {

            return await _context.PhoneContacts.ToListAsync();
        }

        public async Task Insert(PhoneContact phoneContact)
        {
            var newPhoneContact = new PhoneContact()
            {
                Id = Guid.NewGuid(),
                Name = phoneContact.Name,
                PhoneNumber = phoneContact.PhoneNumber,
                Address = phoneContact.Address,
                Descriptions = phoneContact.Descriptions
            };

            _context.PhoneContacts.Add(newPhoneContact);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PhoneContact phoneContact)
        {
            var currentPhoneContact = await _context.PhoneContacts
                .Where(c => c.Id == phoneContact.Id)
                .FirstOrDefaultAsync();

            if (currentPhoneContact != null)
            {
                currentPhoneContact.Name = phoneContact.Name;
                currentPhoneContact.PhoneNumber = phoneContact.PhoneNumber;
                currentPhoneContact.Address = phoneContact.Address;
                currentPhoneContact.Descriptions = phoneContact.Descriptions;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var phoneContactToRemove = await _context.PhoneContacts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (phoneContactToRemove != null)
            {
                _context.PhoneContacts.Remove(phoneContactToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PhoneContact> Find(Guid id)
        {
            return await _context.PhoneContacts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
