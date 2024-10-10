using SB13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB13.Repositories
{
    internal class JournalRepo : Repository<Journal>, IRepository<Journal>
    {
        public JournalRepo() : base() { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Journal Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Journal inputInstance)
        {
            var journalList = SelectAllDataFromJsonFile();

            if (journalList.Count() == 0)
            {
                inputInstance.Id = 1;
            }
            else
            {
                inputInstance.Id = journalList.Max(c => c.Id) + 1;
            }

            journalList.Add(inputInstance);

            SerializeAndWriteToJsonFile(journalList);
        }

        public void Update(Journal inputInstance)
        {
            throw new NotImplementedException();
        }
    }
}
