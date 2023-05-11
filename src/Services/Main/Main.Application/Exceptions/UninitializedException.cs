namespace Main.Application.Exceptions;

public class UninitializedException : InvalidOperationException
{
    public UninitializedException() : base("Property is uninitialized")
    {
    }
}