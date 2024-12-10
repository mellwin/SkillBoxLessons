using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WpfAppDBFirst
{
    public static class CustumerDBRepo
    {
        public static async Task<List<Custumer>> SelectAllCustumers()
        {
            using (var db = new CustumersStorageContext())
            {
                return await db.Custumers.ToListAsync();
            }
        }

        public static async Task Insert(Custumer custumer)
        {
            using (var db = new CustumersStorageContext())
            {
                await db.Custumers.AddAsync(custumer);
                await db.SaveChangesAsync();
            }
        }

        public static async Task Update(Custumer custumer)
        {
            using (var db = new CustumersStorageContext())
            {
                var currentCustumer = await db.Custumers.Where(c => c.Id == custumer.Id).FirstAsync();
                if (currentCustumer != null)
                {
                    currentCustumer.LastName = custumer.LastName;
                    currentCustumer.Name = custumer.Name;
                    currentCustumer.SecondName = custumer.SecondName;
                    currentCustumer.PhoneNumber = custumer.PhoneNumber;
                    currentCustumer.Email = custumer.Email;

                    await db.SaveChangesAsync();
                }
            }
        }

        public static async Task Delete(Guid custumerId)
        {
            using (var db = new CustumersStorageContext())
            {
                db.Custumers.Remove(await db.Custumers.Where(c => c.Id == custumerId).FirstAsync());
                await db.SaveChangesAsync();
            }
        }

        public static async Task<Custumer> Find(Guid custumerId)
        {
            using var db = new CustumersStorageContext();
            return db.Custumers.Where(c => c.Id == custumerId).FirstAsync().Result;
        }
    }
}
