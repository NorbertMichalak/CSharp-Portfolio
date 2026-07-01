class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get {return balance;}
    }

    private List< string> history = new List<string>();

    public IReadOnlyList<string> History => history;
    // Method  to Deposits

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
            return false;

        if (amount > 1_000_000m)
            return false;
        
        
        balance += amount;
        history.Add($"{DateTime.Now}: Deposit {amount}, balance: {balance}");
            return true;
    }

// Method to Withdrawal
    public bool Withdrawal(decimal amount)
    {
        if (amount <= 0)
            return false;
        if (balance < amount)
            return false;

        balance -= amount;
        history.Add($"{DateTime.Now}: Withdrawal {amount}, balance: {balance}");
            return true;
    }
}

