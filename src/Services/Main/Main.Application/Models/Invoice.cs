using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[Owned]
public class Invoice
{
    public double Sum { get; }
    public DateTime OperationTime { get; }

    // ReSharper disable once UnusedMember.Local
    private Invoice()
    {
    }

    public Invoice(DateTime operationTime, double sum)
    {
        Sum = sum;
        OperationTime = operationTime;
    }
}