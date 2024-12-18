// 1 В классе банковский счет, созданном в предыдущих упражнениях, удалить методы заполнения полей.
using BankAccountType;
using BankAccountTransactions;
using Bnk;
using BankAccountTrans;
using Bnk3;


class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
    }

    static void Task1()
    {
        BankAccount account1 = new BankAccount();
        BankAccount account2 = new BankAccount(1000.0);
        BankAccount account3 = new BankAccount(AccType.savings);
        

        Console.WriteLine("информация о счетах:");
        account1.PrintInfo();
        Console.WriteLine();
        account2.PrintInfo();
        Console.WriteLine();
        account3.PrintInfo();
        Console.WriteLine();
        

        Console.WriteLine("перевода 200.0 с account2 на account4:");
        Transactions.Transaction(account2, account3, 200.0);
        Console.WriteLine();

        Console.WriteLine("после перевода:");
        account2.PrintInfo();
        Console.WriteLine();
        account3.PrintInfo();
    }

    // 2 Создать новый класс BankTransaction, который будет хранить информацию о всех банковских операциях.
    static void Task2()
    {
        BankAccount2 account1 = new BankAccount2();
        BankAccount2 account2 = new BankAccount2(1000.0);

        Console.WriteLine("информация о счетах:");
        account1.PrintInfo();
        Console.WriteLine();
        account2.PrintInfo();
        Console.WriteLine();

        account2.Contribution(500.0);
        account2.Withdraw(150.0);
        account2.Withdraw(1000.0);
        Console.WriteLine();
        account2.PrintTransactions();
    }

    // 3 В классе банковский счет создать метод Dispose
    static void Task3()
    {
        BankAccount3 account3 = new BankAccount3(1000.0);
        {
            account3.Contribution(500.0);
            account3.Withdraw(150.0);
            account3.Withdraw(100.0);
            account3.PrintTransactions();
        }
    }
}
