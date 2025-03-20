namespace FinanceManagement;

/// <summary>
/// Фабрика.
/// Создание объектов BankAccount, Category и Operation.
/// </summary>
public static class FinanceFactory
{
    public static BankAccount CreateBankAccount(string name, decimal balance) 
        => new BankAccount(name, balance);

    public static Category CreateCategory(string name, bool isIncome) 
        => new Category(name, isIncome);

    public static Operation CreateOperation(Guid bankAccountId, Guid categoryId, decimal amount, string description = "")
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        return new Operation(bankAccountId, categoryId, amount, description);
    }
}

