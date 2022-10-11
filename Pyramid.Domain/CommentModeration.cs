namespace Pyramid.Domain;

public static class CommentContentModerationValidator
{
    private static readonly string[] BadWords = { "flibbertigibbet" };

    internal static bool IsValid(string content)
    {
        return BadWords.All(badWord => !content.Contains(badWord));
    }
}

public class CommentModerationException : Exception
{
    public CommentModerationException(string content) : base(
        $"The comment \"{content}\" did not pass moderation and is not allowed")
    {

    }
}