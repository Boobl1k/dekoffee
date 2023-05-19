namespace Main.Application.Models;

public class Invoice
{
    public decimal Sum { get; private init; }
    public DateTime OperationTime { get; private init; }

    // ReSharper disable once UnusedMember.Local
    private Invoice()
    {
    }

    public Invoice(DateTime operationTime, decimal sum)
    {
        Sum = sum;
        OperationTime = operationTime;
    }
}