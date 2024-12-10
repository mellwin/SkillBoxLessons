namespace SB13
{
    public class Account
    {
        public static event Action<string, int> AccountFinded;

        public int Id { get; set; }
        public int CustumerId { get; set; }
        public string AccuntNum { get; set; }
        public double Balance { get; set; }

        Account(int id, int custumerId, string accountNum, double balane)
        {
            Id = custumerId;
            CustumerId = custumerId;
            AccuntNum = accountNum;
            Balance = balane;
        }

        public Account(int custumerId, string accountNum)
        {
            CustumerId = custumerId;
            AccuntNum = accountNum;
        }
        public Account() { }
    }
}
