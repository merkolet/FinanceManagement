namespace FinanceManagement.Commands;
using System;
using System.Diagnostics;

/// <summary>
/// Декоратор.
/// </summary>
public class TimedCommandDecorator : ICommand
{
    private ICommand _command;

    public TimedCommandDecorator(ICommand command)
    {
        _command = command;
    }

    public void Execute()
    {
        var startTime = DateTime.Now;
        _command.Execute();
        var endTime = DateTime.Now;
        
        Console.WriteLine($"Время выполнения: {(endTime - startTime).TotalMilliseconds} мс");
    }
    
    public static void MeasureExecutionTime(Action action, string operationName)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        Console.WriteLine($"{operationName} выполнено за {stopwatch.ElapsedMilliseconds} мс");
    }
}

