using Pyramid.Domain;

namespace Pyramid.Tests.EntityBuilders;

public class PostBuilder
{
    private readonly Post _post = new Post(Guid.NewGuid(), "");

    public PostBuilder WithManyComments(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            _post.Comment(Guid.NewGuid(), "");
        }

        return this;
    }

    public Post Build()
    {
        return _post;
    }
}