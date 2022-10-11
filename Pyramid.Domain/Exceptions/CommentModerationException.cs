namespace Pyramid.Domain.Exceptions;

public class CommentModerationException : Exception
{
    public CommentModerationException(string content) : base(
        $"The comment \"{content}\" did not pass moderation and is not allowed")
    {

    }
}