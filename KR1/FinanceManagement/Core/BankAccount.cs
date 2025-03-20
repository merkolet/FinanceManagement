namespace FinanceManagement;
using Export;

/// <summary>
/// Банковский счет.
/// </summary>
public class BankAccount
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get;  set; }

    public BankAccount(string name, decimal balance)
    {
        Id = Guid.NewGuid();
        Name = name;
        Balance = balance;
    }

    public void UpdateBalance(decimal amount)
    {
        Balance += amount;
    }
    
    public void Accept(IExportVisitor visitor)
    {
        visitor.Visit(this);
    }
}

