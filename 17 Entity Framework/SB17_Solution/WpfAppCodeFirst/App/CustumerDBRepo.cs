using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace WpfAppCodeFirst
{
    public static class CustumerDBRepo
    {
        public static async Task<List<Custumer>> SelectAllCustumers()
        {
            using (var db = new CustumerContext())
            {
                var custumers = await db.Custumers.ToListAsync();
                return custumers;
            }
        }

        public static async Task Insert(Custumer custumer)
        {
            using (var db = new CustumerContext())
            {
                db.Custumers.Add(custumer);
                await db.SaveChangesAsync();
            }
        }

        public static async Task Update(Custumer custumer)
        {
            using (var db = new CustumerContext())
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
            using (var db = new CustumerContext())
            {
                db.Custumers.Remove(await db.Custumers.Where(c => c.Id == custumerId).FirstAsync());
                await db.SaveChangesAsync();
            }
        }

        public static async Task<Custumer> Find(Guid custumerId)
        {
            using (var db = new CustumerContext())
            {
                return db.Custumers.Where(c => c.Id == custumerId).FirstAsync().Result;
            }
        }
    }
}
