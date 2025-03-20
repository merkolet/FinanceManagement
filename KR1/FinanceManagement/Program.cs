namespace FinanceManagement;

using Microsoft.Extensions.DependencyInjection;
using Export;
using Import;
using Commands;
using Facade;

class Program
{
    static void Main()
    {
        // 1. Создаём DI-контейнер и регистрируем зависимости
        var serviceProvider = new ServiceCollection()
            .AddSingleton<FinanceFacade>()
            .AddSingleton<IExportVisitor, CsvExportVisitor>()
            .AddSingleton<IExportVisitor, JsonExportVisitor>()
            .AddSingleton<IExportVisitor, YamlExportVisitor>()
            .AddSingleton<DataImporter, CsvDataImporter>()
            .AddSingleton<DataImporter, JsonDataImporter>()
            .AddSingleton<DataImporter, YamlDataImporter>()
            .AddSingleton<ICommand, AddOperationCommand>()
            .AddSingleton<ICommand, TimedCommandDecorator>() 
            .BuildServiceProvider();

        // 2. Получаем основной фасад
        var financeFacade = serviceProvider.GetService<FinanceFacade>();

        // 3. Тестируем функциональность
        if (financeFacade != null)
        {
            financeFacade.RunDemo();
        }
    }
}