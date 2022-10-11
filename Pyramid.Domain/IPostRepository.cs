namespace Pyramid.Domain;

public interface IPostRepository
{
    Post GetPost(Guid postId);
    Guid Add(Post post);
    Post Update(Post post);
}