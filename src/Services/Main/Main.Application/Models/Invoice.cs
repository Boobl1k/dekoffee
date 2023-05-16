﻿namespace Main.Application.Models;

public class Invoice
{
    public decimal Sum { get; }
    public DateTime OperationTime { get; }

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