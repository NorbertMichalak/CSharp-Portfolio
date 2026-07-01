class BusinessAccount : BankAccount
{
    private const decimal overdraftLimit = 10000m;
    private const decimal fee = 50m;

    protected override bool CanWithdraw(decimal amount)
    {
        return balance - amount >= -overdraftLimit;
    }

    public override void ApplyInterest()
    {   
        if (isFrozen)
            return;

        decimal rate = balance >= 0 ? 0.02m : 0.06m;
        decimal interest = Math.Abs(balance) * rate;
        
        if (balance >= 0)
            balance += interest;
        else
            balance -= interest;

        history.Add($"Interest: {interest}, Balance: {balance}");

        CheckFreeze();
    }

    public override void ChargeMaintenanceFee()
    {   
        if (isFrozen)
        return;

        balance -= fee;
        history.Add($"Maintenance fee -{fee}, Balance: {balance}");

        CheckFreeze();
    }

    private void CheckFreeze()
    {
        if (!isFrozen && balance < -overdraftLimit)
        {
            isFrozen = true;
            history.Add($"{DateTime.Now}: ACCOUNT FROZEN. Balance {balance} exceeds overdraft limit of -{overdraftLimit}.");
        }
    }
}