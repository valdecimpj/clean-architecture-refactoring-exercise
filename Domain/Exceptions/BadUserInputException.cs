namespace Domain.Exceptions;

public class BadUserInputException : Exception
{
    public BadUserInputException(string message)
        : base(message) { }
}
