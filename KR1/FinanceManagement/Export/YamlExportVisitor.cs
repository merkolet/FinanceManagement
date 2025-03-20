namespace FinanceManagement.Export;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class YamlExportVisitor : IExportVisitor
{
    private readonly ISerializer _serializer;

    public YamlExportVisitor()
    {
        _serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    }

    public void Visit(BankAccount account)
    {
        string yaml = _serializer.Serialize(account);
        Console.WriteLine("Экспорт счета в YAML:");
        Console.WriteLine(yaml);
    }

    public void Visit(Category category)
    {
        string yaml = _serializer.Serialize(category);
        Console.WriteLine("Экспорт категории в YAML:");
        Console.WriteLine(yaml);
    }

    public void Visit(Operation operation)
    {
        string yaml = _serializer.Serialize(operation);
        Console.WriteLine("Экспорт операции в YAML:");
        Console.WriteLine(yaml);
    }
}

