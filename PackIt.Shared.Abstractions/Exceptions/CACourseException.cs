namespace PackIt.Shared.Abstractions.Exceptions;

public abstract class CACourseException : Exception
{
    protected CACourseException(string message) : base(message)
    {
        
    }
}
