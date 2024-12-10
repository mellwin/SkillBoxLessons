using SB13.Models;
using System;
using System.Threading;

namespace SB13.Repositories
{
    internal class TransactionRepo : Repository<Transaction>, IRepository<Transaction>
    {
        public static event Action<string> TransactionCreatedNotification;

        public TransactionRepo() : base() { }

        public void Insert(Transaction inputInstance)
        {
            var trnList = SelectAllDataFromJsonFile();

            if (trnList.Count() == 0)
            {
                inputInstance.Id = 1;
            }
            else
            {
                inputInstance.Id = trnList.Max(c => c.Id) + 1;
            }

            trnList.Add(inputInstance);

            SerializeAndWriteToJsonFile(trnList);

            TransactionCreatedNotification?.Invoke($"Совершен перевод со счета: {inputInstance.AccountIdFrom} на счет: {inputInstance.AccountIdTo} на сумму: {inputInstance.Sum}");
        }

        public void Delete(int id)
        {
            var trnList = SelectAllDataFromJsonFile();

            foreach (var t in trnList)
            {
                if (t.Id == id) trnList.Remove(t);
            }

            SerializeAndWriteToJsonFile(trnList);
        }

        public void Update(Transaction inputInstance)
        {
            var trnList = SelectAllDataFromJsonFile();

            foreach (var t in trnList)
            {
                if (t.Id == inputInstance.Id)
                {
                    t.AccountIdFrom = inputInstance.AccountIdFrom;
                    t.AccountIdTo = inputInstance.AccountIdTo;
                    t.Sum = inputInstance.Sum;
                    t.DateTimeTransaction = inputInstance.DateTimeTransaction;
                }
            }

            SerializeAndWriteToJsonFile(trnList);
        }

        public Transaction Find(int id)
        {
            var trnList = SelectAllDataFromJsonFile();
            var trn = new Transaction();

            foreach (var t in trnList)
            {
                if (t.Id == id)
                {
                    trn = t;
                    break;
                }
            }

            return trn;
        }
    }
}