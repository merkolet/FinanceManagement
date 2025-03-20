namespace FinanceManagement;

using System;
using System.Collections.Generic;
using System.Linq;

public class FinanceAnalytics
{
    private readonly List<Operation> _operations;

    public FinanceAnalytics(List<Operation> operations)
    {
        _operations = operations;
    }

    // 1. Подсчет разницы доходов и расходов за выбранный период
    public decimal GetNetIncome(DateTime startDate, DateTime endDate)
    {
        var income = _operations
            .Where(o => o.Date >= startDate && o.Date <= endDate)
            .Sum(o => o.Amount);

        return income;
    }

    // 2. Группировка доходов и расходов по категориям
    public Dictionary<Guid, decimal> GetIncomeByCategory()
    {
        return _operations
            .GroupBy(o => o.CategoryId)
            .ToDictionary(g => g.Key, g => g.Sum(o => o.Amount));
    }

    // 3. Количество операций за выбранный период
    public int GetOperationCount(DateTime startDate, DateTime endDate)
    {
        return _operations.Count(o => o.Date >= startDate && o.Date <= endDate);
    }
}