
class Program
{
    static void Main()
    {
        var accounts = new List <BankAccount>
        {
            new CurrentAccount(),
            new SavingsAccount(),
            new BusinessAccount(),
        };
        
            while(true)
            {
                // Raw String Literal
                Console.WriteLine("""
                Select one of the available options:
                1 - Deposit
                2 - Withdraw
                3 - Balance
                4 - Transaction History
                5 - Internal Transfer
                6 - Process month-end
                0 - Exit 
                """);

                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("You didn't provide any options");
                    continue;
                }

                switch(choice)
                {
                    case "0":
                    Console.WriteLine("End of Program");
                    return;

                    case "1":
                    Deposit(accounts);
                    break;

                    case "2":
                    Withdrawal(accounts);
                    break;

                    case "3":
                    ShowBalance(accounts);
                    break;

                    case "4":
                    ShowHistory(accounts);
                    break;

                    case "5":
                    Transfer(accounts);
                    break;

                    case "6":
                    ProcessMonthEnd(accounts);
                    break;

                    default:
                    Console.WriteLine("Wrong choice");
                    break;
                }
            }
    }

    static BankAccount? SelectAccount(List<BankAccount> accounts)
    {
        Console.WriteLine("Select account:");

        for (int i = 0; i < accounts.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {accounts[i].GetType().Name}");
        }

        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number))
            return null;

        if (number < 1|| number > accounts.Count )
            return null;

        return accounts[number - 1];
    }

    static void Deposit(List<BankAccount> accounts)
    {
        Console.WriteLine("Enter amount");
        string input = Console.ReadLine();

        if (!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        BankAccount? selectedAccount = SelectAccount(accounts);

        if (selectedAccount == null)
        {
            Console.WriteLine("Wrong choice");
            return;
        }

        if (selectedAccount.Deposit(amount))
        {
            Console.WriteLine($"Deposited {amount}");
            Console.WriteLine($"Balance: {selectedAccount.Balance:F2}");
        }

        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }

    }

    static void Withdrawal(List<BankAccount> accounts)
    {
        Console.WriteLine("Enter amount");
        string input = Console.ReadLine();

        if(!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        BankAccount? selectedAccount = SelectAccount(accounts);

        if(selectedAccount == null)
        {
            Console.WriteLine("Wrong choice");
            return;
        }

        if(selectedAccount.Withdrawal(amount))
        {
            Console.WriteLine($"Paid out: {amount}");
            Console.WriteLine($"Balance: {selectedAccount.Balance:F2}");
        }

        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }

    static void ShowBalance(List<BankAccount> accounts)
    {
        for (int i = 0; i < accounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {accounts[i].GetType().Name} - balance: {accounts[i].Balance:F2}");
        }
    }

    static void ShowHistory(List<BankAccount> accounts)
    {
        for (int i = 0; i < accounts.Count; i++)
        {
            Console.WriteLine($"\nHistory: {accounts[i].GetType().Name}");

            foreach (var entry in accounts[i].History)
            {
                Console.WriteLine(entry);
            }
        }
    }

    static void Transfer(List<BankAccount> accounts)
    {
        Console.WriteLine("Enter the amount to be transferred");
        string input = Console.ReadLine();

        if (!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        // Source account

        Console.WriteLine("Select the source account:");
        BankAccount? source = SelectAccount(accounts);
        if (source == null)
        {
            Console.WriteLine("Invalid source account selection");
            return;
        }

        // Target account

        Console.WriteLine("Select the target account:");
        BankAccount? target = SelectAccount(accounts);
        if (target == null)
        {
            Console.WriteLine("Invalid target account selection");
            return;
        }

        if (source == target)
        {
            Console.WriteLine("You cannot transfer to the same account!");
            return;
        }

        // Execute Transfer

        if (!source.Withdrawal(amount))
        {
            Console.WriteLine("Transfer failed – insufficient funds or limit exceeded.");
            return;
        }
        
        if (!target.Deposit(amount))
        {
            source.Deposit(amount); // rollback
            Console.WriteLine("Transfer failed. Target account rejected the deposit.");
            return;
        }
            
        Console.WriteLine($@"Transferred {amount} from {source.GetType().Name} to {target.GetType().Name}");
        
    }

    static void ProcessMonthEnd(List<BankAccount> accounts)
    {
        Console.WriteLine("\nProcessing month-end for all accounts...");

        foreach (var account in accounts)
        {   
            if (account.IsFrozen)
            {
                Console.WriteLine($"{account.GetType().Name} is frozen — skipped.");
                continue;
            }
            account.ApplyInterest();
            account.ChargeMaintenanceFee();

            Console.WriteLine(account.IsFrozen
            ? $"{account.GetType().Name} has just been frozen due to excessive debt. Balance: {account.Balance:F2}"
            : $"{account.GetType().Name} processed. New balance: {account.Balance:F2}");
        }
        Console.WriteLine("Month-end processing complete.\n");
    }
    
}
