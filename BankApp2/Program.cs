// BankApp 2.0

class Program
{
    static void Main()
    {
        BankAccount currentAccount = new BankAccount();
        BankAccount savingsAccount = new BankAccount();
        
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
                Deposit(currentAccount, savingsAccount);
                break;

                case "2":
                Withdrawal(currentAccount, savingsAccount);
                break;

                case "3":
                ShowBalance(currentAccount, savingsAccount);
                break;

                case "4":
                ShowHistory(currentAccount, savingsAccount);
                break;

                case "5":
                Transfer(currentAccount, savingsAccount);
                break;

                default:
                Console.WriteLine("Wrong choice");
                break;
            }
        }
    }


    static void Deposit(BankAccount currentAccount, BankAccount savingsAccount)
    {
        Console.WriteLine("Enter amount");
        string input = Console.ReadLine();

        if(!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        Console.WriteLine("Choose account: \n1 - Current Account \n2 - Saving Account");
        string accountChoice = Console.ReadLine();

        // Zamiast zwyklego if else
        BankAccount? selectedAccount =  accountChoice == "1" ? currentAccount:
                                        accountChoice == "2" ? savingsAccount: null;

        if (selectedAccount == null)
        {
            Console.WriteLine("Wrong choice");
            return;
        }

        if (selectedAccount.Deposit(amount))
        {
            Console.WriteLine($"Deposited {amount}");
            Console.WriteLine($"Balance: {selectedAccount.Balance}");
        }

        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }


    }

    static void Withdrawal(BankAccount currentAccount, BankAccount savingsAccount)
    {
        Console.WriteLine("Enter amount to withdraw:");
        string input = Console.ReadLine();

        if(!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        Console.WriteLine("Choose account: \n1 - Current Account \n2 - Savings Account");
        string accountChoice = Console.ReadLine();

        // Zamiast zwyklego if else
        BankAccount? selectedAccount =  accountChoice == "1" ? currentAccount:
                                        accountChoice == "2" ? savingsAccount: null;

        if (selectedAccount == null)
        {
            Console.WriteLine("Wrong choice");
            return;
        }

        if (selectedAccount.Withdrawal(amount))
        {
            Console.WriteLine($"Paid out {amount}");
            Console.WriteLine($"Balance: {selectedAccount.Balance}");
        }

        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }

    }

    static void ShowBalance(BankAccount currentAccount, BankAccount savingsAccount)
    {
        Console.WriteLine($"Current Account Balance: {currentAccount.Balance}");
        Console.WriteLine($"Saving Account Balance: {savingsAccount.Balance}");
    }

    static void ShowHistory(BankAccount currentAccount, BankAccount savingsAccount)
    {   
        Console.WriteLine("\n History from Current Account");
        foreach (var entry in currentAccount.History)
        {
            Console.WriteLine(entry);
        }

        Console.WriteLine("History from Savings Account");
        foreach (var entry in savingsAccount.History)
        {
            Console.WriteLine(entry);
        }

    }

    static void Transfer(BankAccount currentAccount, BankAccount savingsAccount)
    {   
        Console.WriteLine("Enter the amount to be transferred");
        string input = Console.ReadLine();

        if (!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Is not a number!");
            return;
        }

        Console.WriteLine("""
        Select a transfer direction:
        1 - From Current Account to Savings
        2 - From Savings to Current Account
        """);

        string accountChoice = Console.ReadLine();

        BankAccount? source = accountChoice == "1" ? currentAccount :
                              accountChoice == "2" ? savingsAccount : null;

        BankAccount? destination = accountChoice == "1" ? savingsAccount :
                                   accountChoice == "2" ? currentAccount : null;

        if (source == null || destination == null)
        {
            Console.WriteLine("Wrong choice");
            return;
        }
        
        if (!source.Withdrawal(amount))
        {
            Console.WriteLine("Transfer failed. Invalid amount or insufficient funds.");
            return;
        }
        
        if (!destination.Deposit(amount))
        {
            source.Deposit(amount); 
            Console.WriteLine("Transfer failed. Destination account rejected the deposit.");
            return;
        }

        Console.WriteLine($"""
        Transferred {amount} from {(source == currentAccount ? "Current" : "Savings")} 
        to {(destination == currentAccount ? "Current" : "Savings")}
        """);
    }

}