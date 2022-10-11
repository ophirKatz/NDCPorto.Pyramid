namespace Pyramid.Domain.Events;

public class CommentBlocked : DomainEvent
{
    public CommentBlocked(Guid postId, Guid authorId, string content)
    {
        PostId = postId;
        AuthorId = authorId;
        Content = content;
    }

    public Guid PostId { get; }
    public Guid AuthorId { get; }
    public string Content { get; }
}