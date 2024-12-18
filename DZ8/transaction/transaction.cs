using BankAccountType;
namespace BankAccountTransactions
{
    public static class Transactions
    {
        public static void Transaction(BankAccount fromAccount, BankAccount toAccount, double amount)
        {
            if (fromAccount.balance >= amount)
            {
                fromAccount.balance -= amount;
                toAccount.balance += amount;
                Console.WriteLine($"Перевод успешен: {amount} переведено с {fromAccount.accountNumber} на {toAccount.accountNumber}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для перевода.");
            }
        }
    }
}
