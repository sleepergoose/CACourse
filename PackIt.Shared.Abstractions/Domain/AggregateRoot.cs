namespace PackIt.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
    private bool _versionIncremented = false;

    private readonly List<IDomainEvent> _events = new();


    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent @event)
    {
        if (!(_events.Count != 0 || _versionIncremented))
        {
            Version++;
            _versionIncremented = true;

            _events.Add(@event);
        }
    }

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}
