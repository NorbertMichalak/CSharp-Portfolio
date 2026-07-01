class SavingsAccount : BankAccount
{
    private const decimal withdrawalLimit = 2000m;
    private const decimal interestRate = 0.05m;

    protected override bool CanWithdraw(decimal amount)
    {
        return amount <= withdrawalLimit && balance >= amount;
    }

    public override void ApplyInterest()
    {
        decimal interest = balance * interestRate;
        balance += interest;

        history.Add($"Interest +{interest}, Balance: {balance}");
    }

    public override void ChargeMaintenanceFee()
    {
        history.Add("Maintenance fee: 0");
    }
}