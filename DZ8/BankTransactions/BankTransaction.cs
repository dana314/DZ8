using System;
namespace BankAccountTrans
{
    public class BankTransaction
    {
        public DateTime TransactionDate { get; }
        public double Amount { get; }

        public BankTransaction(double amount)
        {
            TransactionDate = DateTime.Now; 
            Amount = amount; 
        }
    }
}
