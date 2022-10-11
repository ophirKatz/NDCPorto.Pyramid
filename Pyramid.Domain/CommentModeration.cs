using Pyramid.Domain.Exceptions;

namespace Pyramid.Domain;

public static class CommentModeration
{
    private static readonly string[] BadWords = { "flibbertigibbet" };

    internal static string Check(string content)
    {
        if (BadWords.Any(content.Contains))
        {
            throw new CommentModerationException(content);
        }

        return content;
    }
}