namespace Pyramid.Domain.Exceptions;

public class CommentDoesNotExistException : Exception
{
    public CommentDoesNotExistException(Guid commentId) : base($"Comment with id {commentId} does not exist")
    {
        
    }
}