namespace FinanceManagement.Commands;
using Facade;

/// <summary>
/// Добавление операции.
/// </summary>
public class AddOperationCommand : ICommand
{
    private FinanceFacade _facade;
    private Guid _accountId;
    private Guid _categoryId;
    private decimal _amount;
    private string _description;

    public AddOperationCommand(FinanceFacade facade, Guid accountId, Guid categoryId, decimal amount, string description = "")
    {
        _facade = facade;
        _accountId = accountId;
        _categoryId = categoryId;
        _amount = amount;
        _description = description;
    }

    public void Execute()
    {
        _facade.AddOperation(_accountId, _categoryId, _amount, _description);
    }
}

