namespace FinanceManagement;
using Export;

/// <summary>
/// Категория операции.
/// </summary>
public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsIncome { get; private set; }

    public Category(string name, bool isIncome)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsIncome = isIncome;
    }
    
    public void Accept(IExportVisitor visitor)
    {
        visitor.Visit(this);
    }
}

