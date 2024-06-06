using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public sealed class PackingListNotFoundException : CACourseException
{
    public Guid Id { get; }

    public PackingListNotFoundException(Guid id)
        : base($"Packing List with Id '{id}' is not found")
    {
        Id = id;
    }
}
