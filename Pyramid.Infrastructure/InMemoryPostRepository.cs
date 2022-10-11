using Pyramid.Domain;
using Pyramid.Domain.Events;

namespace Pyramid.Infrastructure;

public class InMemoryPostRepository : IPostRepository
{
    private readonly IEventPublisher _eventPublisher;
    private readonly List<Post> _posts = new();

    public InMemoryPostRepository(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public Post GetPost(Guid postId)
    {
        return _posts.First(x => x.Id == postId);
    }

    public Guid Add(Post post)
    {
        _posts.Add(post);
        return post.Id;
    }

    public Post Update(Post post)
    {
        // Triggering all domain-event handlers (side-effects)
        var domainEvents = post.Events.ToList();
        foreach (var domainEvent in domainEvents)
        {
            _eventPublisher.Publish(domainEvent);
        }

        return post;
    }
}