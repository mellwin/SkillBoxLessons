using SB14.BankPrototype.Models;

namespace SB14.Repositories
{
    internal class AccountRepo : Repository<Account>, IRepository<Account>
    {
        public static event Action<string> AccnountCreatedNotification;
        public static event Action<string> AccnountCheckCurrentBalanceNotification;

        public AccountRepo() : base() { }
        public void Insert(Account inputInstance)
        {
            var accountList = SelectAllDataFromJsonFile();

            if (accountList.Count() == 0)
            {
                inputInstance.Id = 1;
            }
            else
            {
                inputInstance.Id = accountList.Max(c => c.Id) + 1;
            }

            accountList.Add(inputInstance);

            SerializeAndWriteToJsonFile(accountList);
            AccnountCreatedNotification?.Invoke($"Создан новый счет: {inputInstance.AccuntNum}");
        }

        public void Delete(int id)
        {
            var accountList = SelectAllDataFromJsonFile();

            foreach (var a in accountList)
            {
                if (a.Id == id) accountList.Remove(a);
            }
            SerializeAndWriteToJsonFile(accountList);
        }

        public void Update(Account inputInstance)
        {
            var accList = SelectAllDataFromJsonFile();

            foreach (var a in accList)
            {
                if (a.Id == inputInstance.Id)
                {
                    a.AccuntNum = inputInstance.AccuntNum;
                    a.Balance = inputInstance.Balance;
                }
            }
            SerializeAndWriteToJsonFile(accList);
            AccnountCheckCurrentBalanceNotification($"Текущий баланс счета {inputInstance.AccuntNum} = {inputInstance.Balance}");
        }

        public Account Find(int id)
        {
            var accountList = SelectAllDataFromJsonFile();
            var account = new Account();

            foreach (var a in accountList)
            {
                if (a.Id == id)
                {
                    account = a;
                    break;
                }
            }

            return account;
        }
    }
}
