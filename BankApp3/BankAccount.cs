abstract class BankAccount
{
    protected decimal balance;
    protected bool isFrozen;
    protected List<string> history = new List<string>();
    public decimal Balance => balance;
    public bool IsFrozen => isFrozen;
    public IReadOnlyList<string> History => history;
    
    public virtual bool Deposit(decimal amount)
    {
        if(amount <= 0)
        return false;

        balance += amount;
        history.Add($"{DateTime.Now}: Deposit: {amount:F2} Balance {balance:F2}");
        return true;
    }

    public virtual bool Withdrawal(decimal amount)
    {
        if (amount <= 0)
            return false;

        if (isFrozen)
            return false;

        if (!CanWithdraw(amount))
            return false;

        balance -= amount;
        history.Add($"{DateTime.Now}: Withdrawal: {amount:F2} Balance: {balance:F2}");
        return true;
    }

    protected abstract bool CanWithdraw(decimal amount);
    public abstract void ApplyInterest();
    public abstract void ChargeMaintenanceFee();


}