using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Domain;

namespace PackIt.Domain.Events;

public record PackingItemAdded(PackingList PackingList, PackingListItem PackingListItem) : IDomainEvent;
