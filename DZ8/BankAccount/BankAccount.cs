using System;
namespace BankAccountType
{
    public enum AccType
    {
        savings,
        active
    }

    public class BankAccount
    {
        public static Random random = new Random();
        public string accountNumber;
        public double balance;
        public AccType accountType;

        public BankAccount()
        {
            this.accountNumber = AccountNumberRandom();
            this.balance = 0.0;
            this.accountType = AccType.active;
        }

        public BankAccount(double balance)
        {
            this.accountNumber = AccountNumberRandom();
            this.balance = balance;
            this.accountType = AccType.active;
        }

        public BankAccount(AccType accountType)
        {
            this.accountNumber = AccountNumberRandom();
            this.balance = 0.0;
            this.accountType = accountType;
        }

        public BankAccount(double balance, AccType accountType)
        {
            this.accountNumber = AccountNumberRandom();
            this.balance = balance;
            this.accountType = accountType;
        }

        private string AccountNumberRandom()
        {
            return $"номер {random.Next(100):D2}";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
    }
}
