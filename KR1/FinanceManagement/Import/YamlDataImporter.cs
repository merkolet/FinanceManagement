namespace FinanceManagement.Import;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class YamlDataImporter : DataImporter
{
    protected override List<Operation> ParseData(string content)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        return deserializer.Deserialize<List<Operation>>(content);
    }
}
