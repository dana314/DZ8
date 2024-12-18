using BankAccountTrans;
using BankAccountType;
using System;
using System.Collections.Generic;

namespace Bnk
{
    public class BankAccount2
    {
        public static Random random = new Random();
        public string AccountNumber { get; }
        public double Balance { get; private set; }
        public AccType AccountType { get; }
        private Queue<BankTransaction> transactions;

        public BankAccount2()
        {
            AccountNumber = AccountNumberRandom();
            Balance = 0.0;
            AccountType = AccType.active;
            transactions = new Queue<BankTransaction>();
        }

        public BankAccount2(double balance) : this()
        {
            Balance = balance;
        }

        public BankAccount2(AccType accountType) : this()
        {
            AccountType = accountType;
        }

        public BankAccount2(double balance, AccType accountType) : this(balance)
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
                Console.WriteLine($"На счет {AccountNumber} добавлено {amount}. Текущий баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                transactions.Enqueue(new BankTransaction(-amount)); 
                Console.WriteLine($"С счета {AccountNumber} снято {amount}. Текущий баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или сумма должна быть положительной.");
            }
        }

        public void PrintTransactions()
        {
            Console.WriteLine($"Транзакции для счета {AccountNumber}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {AccountType}");
        }
    }
}
