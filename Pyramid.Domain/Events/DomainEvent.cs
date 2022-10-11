using MediatR;

namespace Pyramid.Domain.Events;

public class DomainEvent : INotification
{
    
}

public interface IEventPublisher
{
    void Publish(INotification @event);
}