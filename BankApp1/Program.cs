// Console BankApp 1.0


class Program
{

    static void Main()
    {
        BankAccount account = new BankAccount();

        while(true)
        {
            Console.WriteLine("Select one of the available options: 1 - Deposit 2 - Withdrawal 0- Exit");
            string choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("You didn't provide any options");
                continue;
            }

            if (choice == "0")
            {
                Console.WriteLine("End of Program");
                break;
            }

            switch(choice)
            {
                case "1":
                Deposit(account);
                break;

                case "2":
                Withdrawal(account);
                break;

                default:
                Console.WriteLine("Wrong choice");
                break;
            }
        }
        Console.WriteLine("\nHistory of operations");
        foreach (var entry in account.History )
        {
        Console.WriteLine(entry);
        }

    }

        static void Deposit(BankAccount account)
    {
        Console.WriteLine("Enter the amount to be paid.");
        string input = Console.ReadLine();

        if(!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        if(account.Deposit(amount))
        {
            Console.WriteLine($"Paid in {amount}");
            Console.WriteLine($"Saldo: {account.Balance}");
        }

        else
        {
            Console.WriteLine("Operation error");
        }

    }

    static void Withdrawal(BankAccount account)
    {
        Console.WriteLine("Please provide the payout amount.");
        string input = Console.ReadLine();

        if(!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        if (account.Withdrawal(amount))
        {
            Console.WriteLine($"Paid out: {amount}");
            Console.WriteLine($"Saldo: {account.Balance}");
        }

        else
        {
            Console.WriteLine("Operation error or insufficient funds in the account.");
        }
    }
}

