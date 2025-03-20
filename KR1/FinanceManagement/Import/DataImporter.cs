namespace FinanceManagement.Import;

public abstract class DataImporter
{
    public void Import(string filePath)
    {
        string content = ReadFile(filePath);
        List<Operation> operations = ParseData(content);
        SaveOperations(operations);
    }

    protected string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    protected abstract List<Operation> ParseData(string content);

    protected void SaveOperations(List<Operation> operations)
    {
        Console.WriteLine($"Импортировано {operations.Count} операций.");
    }
}


