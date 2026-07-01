class CurrentAccount : BankAccount
{
    private const decimal overdraftLimit = 1500m;
    private const decimal fee = 10m;

    protected override bool CanWithdraw(decimal amount)
    {
        return balance - amount >= -overdraftLimit;
    }

    public override void ApplyInterest()
    {   
        if (isFrozen)
            return;

        if (balance < 0)
        {
            decimal interest = Math.Abs(balance) * 0.10m;
            balance -= interest;

            history.Add($"Overdraft interest -{interest}, Balance: {balance}");
        }
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