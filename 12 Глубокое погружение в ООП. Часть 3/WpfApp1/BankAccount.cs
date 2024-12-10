using System;

namespace WPFApp
{
    public class BankAccount : IBankAccount
    {
        public Guid Id { get; set; }
        public double Balance { get; }



        public void AddSum(double sum)
        {
            throw new System.NotImplementedException();
        }

        public double TakeSum(double sum)
        {
            throw new System.NotImplementedException();
        }
    }
}