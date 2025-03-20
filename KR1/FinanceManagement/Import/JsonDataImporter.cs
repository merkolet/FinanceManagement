namespace FinanceManagement.Import;

using System.Text.Json;

public class JsonDataImporter : DataImporter
{
    protected override List<Operation> ParseData(string content)
    {
        return JsonSerializer.Deserialize<List<Operation>>(content);
    }
}
