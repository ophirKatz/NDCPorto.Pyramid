namespace Pyramid.Domain;

public class Comment
{
    public Comment(Guid id, Guid authorId, string content)
    {
        Id = id;
        AuthorId = authorId;
        Content = content;
    }

    public Guid Id { get; }
    public Guid AuthorId { get; }
    public string Content { get; private set; }

    internal void Edit(string newContent)
    {
        Content = newContent;
    }
}