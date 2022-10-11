using MediatR;
using Pyramid.Domain.Events;

namespace Pyramid.Infrastructure;

public class MediatREventPublisher : IEventPublisher
{
    private readonly IPublisher _publisher;

    public MediatREventPublisher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public void Publish(INotification @event)
    {
        _publisher.Publish(@event);
    }
}