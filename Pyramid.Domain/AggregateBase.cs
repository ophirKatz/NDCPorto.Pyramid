using Pyramid.Domain.Events;

namespace Pyramid.Domain;

public class AggregateBase
{
    public List<DomainEvent> Events { get; } = new();
}