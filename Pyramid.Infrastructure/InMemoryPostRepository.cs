using Pyramid.Domain;

namespace Pyramid.Infrastructure;

public class InMemoryPostRepository : IPostRepository
{
    private readonly List<Post> _posts = new();

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
        // Nothing to do for in-memory collection
        return post;
    }
}