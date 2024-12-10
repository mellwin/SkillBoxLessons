namespace WPFApp
{
    public ref struct Transaction
    {
        public readonly int Amount;
        public readonly string To;

        public Transaction(in int amount, in string to)
        {
            Amount = amount;
            To = to;
        }
    }

    class TransactionBuiler
    {
        protected int amount;
        protected string to;

        public TransactionBuiler WithAmount(int amount)
        {
            this.amount = amount;
            return this;
        }

        public TransactionBuiler To(string to)
        {
            this.to = to;
            return this;
        }

        public Transaction GetTransaction()
        {
            return new(amount, to);

        }
    }

}