namespace FinanceManagement.Import;

public class CsvDataImporter : DataImporter
{
    protected override List<Operation> ParseData(string content)
    {
        var operations = new List<Operation>();
        var lines = content.Split('\n');

        foreach (var line in lines.Skip(1)) // Пропускаем заголовок
        {
            var values = line.Split(',');
            if (values.Length < 4) continue;

            var operation = new Operation(
                Guid.Parse(values[0]),
                Guid.Parse(values[1]),
                decimal.Parse(values[2]),
                values[3]);

            operations.Add(operation);
        }

        return operations;
    }
}
