namespace FinanceManagement.Export;

using System.Text.Json;

public class JsonExportVisitor : IExportVisitor
{
    public void Visit(BankAccount account)
    {
        string json = JsonSerializer.Serialize(account, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Экспорт счета в JSON:");
        Console.WriteLine(json);
    }

    public void Visit(Category category)
    {
        string json = JsonSerializer.Serialize(category, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Экспорт категории в JSON:");
        Console.WriteLine(json);
    }

    public void Visit(Operation operation)
    {
        string json = JsonSerializer.Serialize(operation, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Экспорт операции в JSON:");
        Console.WriteLine(json);
    }
}


