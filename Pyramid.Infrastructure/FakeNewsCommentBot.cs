using Pyramid.Domain;

namespace Pyramid.Infrastructure;

public class FakeNewsCommentBot : ICommentBot
{
    public string GetNextComment()
    {
        // TODO : Use http to talk with the <b>External</b> fake-news service and fetch a comment
        return string.Empty;
    }
}