using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public class PackingListAlreadyExistsException : CACourseException
{
    public string Name { get; }

    public PackingListAlreadyExistsException(string name)
        : base($"Packing list with a name '{name}' already exists.")
    {
        Name = name;
    }
}
