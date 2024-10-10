namespace WpfApp1
{
    public class Transaction
    {   
        public int Id { get; set; }
        public int AccountIdFrom { get; set; }
        public int AccountIdTo { get; set; }
        public double Sum { get; set; }
        public DateTime DateTimeTransaction { get; set; }

        public Transaction(int accountIdFrom, int accountIdTo, double sum, DateTime dateTimeTransacion)
        {
            AccountIdFrom = accountIdFrom;
            AccountIdTo = accountIdTo;
            Sum = sum;
            DateTimeTransaction = dateTimeTransacion;
        }

        public Transaction()
        {
        }
    }
}