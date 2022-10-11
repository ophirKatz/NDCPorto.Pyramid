using FluentAssertions;
using Moq;
using Pyramid.Application;
using Pyramid.Domain;
using System;
using System.Linq;
using Xunit;

namespace Pyramid.IntegrationTests.Application;

public class PostServiceTests
{
    private readonly Mock<ICommentBot> _commentBotMock = new();
    private readonly Mock<IPostRepository> _postRepositoryMock = new();
    private readonly Mock<IAdminEmail> _adminEmailMock = new();
    
    [Fact]
    public void AddBotCommentOnPost_WhenPostExists_ShouldAddANewCommentFromBot()
    {
        // Arrange
        var post = new Post(Guid.NewGuid(), "Some content");
        // Mocking the repository
        _postRepositoryMock.Setup(repo => repo.GetPost(It.IsAny<Guid>()))
            .Returns(post);
        var postRepository = _postRepositoryMock.Object;

        const string botComment = "The earth is flat!";
        // Mocking the comment bot
        _commentBotMock.Setup(bot => bot.GetNextComment())
            .Returns(botComment);
        // Creating the SUT, passing the mocks as dependencies
        var sut = new PostService(postRepository, _commentBotMock.Object);

        // Act
        sut.AddBotCommentOnPost(post.Id, Guid.NewGuid());

        // Assert
        // This is to ensure the post is actually updated (which is also part of the use-case logic)
        var postAfterAction = postRepository.GetPost(post.Id);
        postAfterAction.Comments.First().Content.Should().Be(botComment);
    }

    //// With side-effect - sending an admin email.
    //[Fact]
    //public void AddBotCommentOnPost_WithProfanity_ShouldNotAddCommentAndSendAnEmail()
    //{
    //    // Arrange
    //    var post = new Post(Guid.NewGuid(), "Some content");
        
    //    // Setup MediatR...
    //    var services = new ServiceCollection();
    //    services.AddMediatR(typeof(CommentBlocked).Assembly, typeof(PostEventHandlers).Assembly);
    //    services.AddSingleton(_adminEmailMock.Object);
    //    var sp = services.BuildServiceProvider();
    //    var publisher = sp.GetRequiredService<IPublisher>();
    //    var postRepository = new InMemoryPostRepository(new MediatREventPublisher(publisher));
    //    postRepository.Add(post);

    //    const string botComment = "flibbertigibbet";
    //    // Mocking the comment bot
    //    _commentBotMock.Setup(bot => bot.GetNextComment())
    //        .Returns(botComment);
    //    // Creating the SUT, passing the mocks as dependencies
    //    var sut = new PostService(postRepository, _commentBotMock.Object);

    //    // Act
    //    sut.AddBotCommentOnPost(post.Id, Guid.NewGuid());

    //    // Assert
    //    // This is to ensure the post is actually updated (which is also part of the use-case logic)
    //    var postAfterAction = postRepository.GetPost(post.Id);
    //    using (new AssertionScope())
    //    {
    //        postAfterAction.Comments.Should().BeEmpty();
    //        _adminEmailMock.Verify(email => email.Send(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    //    }
    //}
}