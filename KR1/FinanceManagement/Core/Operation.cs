namespace FinanceManagement;
using Export;

/// <summary>
/// Финансовые операции.
/// </summary>
public class Operation
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid BankAccountId { get; private set; }
    public Guid CategoryId { get; private set; }

    public Operation(Guid bankAccountId, Guid categoryId, decimal amount, string description = "")
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Id = Guid.NewGuid();
        Amount = amount;
        Date = DateTime.Now;
        Description = description;
        BankAccountId = bankAccountId;
        CategoryId = categoryId;
    }
    
    public void Accept(IExportVisitor visitor)
    {
        visitor.Visit(this);
    }
}

