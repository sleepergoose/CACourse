using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class EmptyLocalizationArgumentException : CACourseException
{
    public EmptyLocalizationArgumentException() : base("Provided value for Localization cannot be empty")
    {
    }
}
