using Pyramid.Domain;

namespace Pyramid.Application;

public class PostService
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentBot _commentBot;

    public PostService(IPostRepository postRepository, ICommentBot commentBot)
    {
        _postRepository = postRepository;
        _commentBot = commentBot;
    }

    public void AddBotCommentOnPost(Guid postId, Guid botAuthorId)
    {
        var post = _postRepository.GetPost(postId);

        var botComment = _commentBot.GetNextComment();
        post.Comment(botAuthorId, botComment);

        _postRepository.Update(post);
    }
}