namespace Pyramid.Domain;

/// <summary>
/// This is an aggregate
/// </summary>
public class Post : AggregateBase
{
    public Post(Guid id, string content)
    {
        Id = id;
        Content = content;
        _likes = new List<Guid>();
        _comments = new List<Comment>();
        _shares = new List<Guid>();
    }

    public Guid Id { get; }
    public string Content { get; }

    private readonly List<Guid> _likes;
    public IReadOnlyList<Guid> Likes => _likes.AsReadOnly();

    private readonly List<Comment> _comments;
    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

    private readonly List<Guid> _shares;
    public IReadOnlyList<Guid> Shares => _shares.AsReadOnly();

    public void ToggleLike(Guid likerId)
    {
        // TODO : Remove else
        if (_likes.Contains(likerId))
        {
            _likes.Remove(likerId);
        }
        else
        {
            _likes.Add(likerId);
        }
    }

    public Guid Comment(Guid authorId, string content)
    {
        if (_comments.Count == 10)
        {
            return Guid.Empty;
        }

        var comment = new Comment(Guid.NewGuid(), authorId, content);
        _comments.Add(comment);
        return comment.Id;
    }

    //// Comment w\ side-effects
    //public Guid Comment(Guid authorId, string content)
    //{
    //    try
    //    {
    //        var comment = new Comment(Guid.NewGuid(), authorId, content);
    //        _comments.Add(comment);
    //        return comment.Id;
    //    }
    //    catch (CommentModerationException)
    //    {
    //        Events.Add(new CommentBlocked(Id, authorId, content));
    //        return Guid.Empty;
    //    }
    //}

    public void EditComment(Guid commentId, string newContent)
    {
        var comment = _comments.FirstOrDefault(x => x.Id == commentId);
        comment.Edit(newContent);
    }
}