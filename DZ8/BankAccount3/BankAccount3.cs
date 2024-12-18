using BankAccountTrans;
using BankAccountType;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bnk3
{
    public class BankAccount3 
    {
        public static Random random = new Random();
        public string AccountNumber { get; }
        public double Balance { get; private set; }
        public AccType AccountType { get; }

        
        private Queue<BankTransaction> transactions;
        private bool disposed = false; 

        public BankAccount3()
        {
            AccountNumber = AccountNumberRandom();
            Balance = 0.0;
            AccountType = AccType.active;
            transactions = new Queue<BankTransaction>();
        }

        public BankAccount3(double balance) : this()
        {
            Balance = balance;
        }

        public BankAccount3(AccType accountType) : this()
        {
            AccountType = accountType;
        }

        public BankAccount3(double balance, AccType accountType) : this(balance)
        {
            AccountType = accountType;
        }

        private string AccountNumberRandom()
        {
            return $"номер {random.Next(100):D2}"; 
        }

        public void Contribution(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Enqueue(new BankTransaction(amount)); 
                Console.WriteLine($" добавлено {amount}. баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("сумма должна быть положительной.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                transactions.Enqueue(new BankTransaction(-amount)); 
                Console.WriteLine($"снято {amount}.  баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("недостаточно средств или сумма должна быть положительной.");
            }
        }

        public void PrintTransactions()
        {
            Console.WriteLine($" {AccountNumber}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"дата: {transaction.TransactionDate}, сумма: {transaction.Amount}");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"номер счета: {AccountNumber}");
            Console.WriteLine($"баланс: {Balance}");
            Console.WriteLine($"тип счета: {AccountType}");
        }

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    
                    WriteTransactionsToFile();
                }
                

                disposed = true; 
            }
        }
        private void WriteTransactionsToFile()
        {
            using (StreamWriter writer = new StreamWriter($"{AccountNumber}_transactions.txt"))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"дата: {transaction.TransactionDate}, сумма: {transaction.Amount}");
                }
            }
           
        }
    }
}
