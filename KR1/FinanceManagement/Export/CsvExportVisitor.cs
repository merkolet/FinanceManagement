namespace FinanceManagement.Export;
using Facade;
public class CsvExportVisitor : IExportVisitor
{
    public void Visit(BankAccount account)
    {
        string csv = $"{account.Id},{account.Name},{account.Balance}";
        Console.WriteLine("Экспорт счета в CSV:");
        Console.WriteLine(csv);
    }

    public void Visit(Category category)
    {
        string csv = $"{category.Id},{category.Name},{(category.IsIncome ? "Доход" : "Расход")}";
        Console.WriteLine("Экспорт категории в CSV:");
        Console.WriteLine(csv);
    }

    public void Visit(Operation operation)
    {
        string csv = $"{operation.Id},{operation.BankAccountId},{operation.CategoryId},{operation.Amount},{operation.Description}";
        Console.WriteLine("Экспорт операции в CSV:");
        Console.WriteLine(csv);
    }
}



