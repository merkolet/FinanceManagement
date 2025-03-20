namespace FinanceManagement.Facade;
using Commands;
using Export;

/// <summary>
/// Фасад.
/// Создание счета, категорий, операций.
/// Управление балансом.
/// Вывод отчета.
/// </summary>
public class FinanceFacade
{
    private List<BankAccount> _accounts = new List<BankAccount>();
    private List<Category> _categories = new List<Category>();
    private List<Operation> _operations = new List<Operation>();

    public BankAccount AddAccount(string name, decimal balance)
    {
        var account = FinanceFactory.CreateBankAccount(name, balance);
        _accounts.Add(account);
        return account;
    }

    public Category AddCategory(string name, bool isIncome)
    {
        var category = FinanceFactory.CreateCategory(name, isIncome);
        _categories.Add(category);
        return category;
    }

    public Operation AddOperation(Guid accountId, Guid categoryId, decimal amount, string description = "")
    {
        var operation = FinanceFactory.CreateOperation(accountId, categoryId, amount, description);
        _operations.Add(operation);
        
        var account = _accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            account.UpdateBalance(amount);
        }

        return operation;
    }

    public void PrintReport()
    {
        Console.WriteLine("=== Финансовый отчет ===");
        foreach (var account in _accounts)
        {
            Console.WriteLine($"Счет: {account.Name}, Баланс: {account.Balance:C}");
        }
    }
    
    public void RecalculateBalances()
    {
        foreach (var account in _accounts)
        {
            var operations = _operations.Where(o => o.BankAccountId == account.Id);
            account.Balance = operations.Sum(o => o.Amount);
        }
    }
    
    public void RunDemo()
    {
        Console.WriteLine("=== Запуск демо-финансового менеджмента ===");

        // 1. Создаем тестовые данные
        var account = new BankAccount("Основной счет", 1000);
        var category = new Category("Зарплата", true);
        var operation = new Operation(account.Id, category.Id, 5000, "Зарплата");

        _accounts.Add(account);
        _categories.Add(category);
        _operations.Add(operation);

        // 2. Добавляем операцию через паттерн Command
        var addOperationCommand = new AddOperationCommand(
            this,                
            operation.BankAccountId, 
            operation.CategoryId,   
            operation.Amount,        
            operation.Description    
        );

        var timedCommand = new TimedCommandDecorator(addOperationCommand);
        timedCommand.Execute();

        // 3. Аналитика
        var analytics = new FinanceAnalytics(_operations);
        Console.WriteLine($"Чистый доход за месяц: {analytics.GetNetIncome(DateTime.Now.AddMonths(-1), DateTime.Now)}");

        // 4. Экспорт данных
        var csvExporter = new CsvExportVisitor();
        csvExporter.Visit(operation);

        // 5. Пересчет баланса
        TimedCommandDecorator.MeasureExecutionTime(() => RecalculateBalances(), "Пересчет баланса");

        Console.WriteLine("=== Демо-запуск завершён! ===");
    }
}

