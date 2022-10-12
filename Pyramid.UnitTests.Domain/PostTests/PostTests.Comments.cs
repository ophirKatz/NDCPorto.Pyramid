using FluentAssertions;
using FluentAssertions.Execution;
using Pyramid.Domain;
using Pyramid.Domain.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace Pyramid.UnitTests.Domain.PostTests;

public partial class PostTests
{
    [Fact]
    public void Comment_ShouldAddAComment()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        const string content = "Some comment content";
        var post = new Post(Guid.NewGuid(), "Some content");

        // Act
        var commentId = post.Comment(authorId, content);

        // Assert
        using (new AssertionScope())
        {
            var assertion = post.Comments.Should().Contain(c => c.Id == commentId);
            var comment = assertion.Subject;
            comment.AuthorId.Should().Be(authorId);
            comment.Content.Should().Be(content);
        }
    }

    [Fact]
    public void Comment_WithBadWord_ShouldThrowModerationException()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        const string content = "flibbertigibbet";
        var post = new Post(Guid.NewGuid(), "Some content");

        // Act
        var action = () => post.Comment(authorId, content);

        // Assert
        using (new AssertionScope())
        {
            var assertion = action.Should().Throw<CommentModerationException>();
            var exception = assertion.Subject.First();
            exception.Message.Should().Be($"The comment \"{content}\" did not pass moderation and is not allowed");
        }
    }

    [Fact]
    public void EditComment_ForExistingComment_ShouldChangeTheContent()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        const string content = "Some comment content";
        const string newContent = "Some new content";
        var post = new Post(Guid.NewGuid(), "Some content");
        var commentId = post.Comment(authorId, content);

        // Act
        post.EditComment(commentId, newContent);

        // Assert
        using (new AssertionScope())
        {
            var assertion = post.Comments.Should().Contain(c => c.Id == commentId);
            var comment = assertion.Subject;
            comment.Content.Should().Be(newContent);
        }
    }

    [Fact]
    public void EditComment_ForNonExistentComment_ShouldThrowCommentDoesNotExistException()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        const string content = "Some comment content";
        var commentId = Guid.NewGuid();
        var post = new Post(Guid.NewGuid(), "Some content");

        // Act
        var action = () => post.EditComment(commentId, content);

        // Assert
        using (new AssertionScope())
        {
            var assertion = action.Should().Throw<CommentDoesNotExistException>();
            var exception = assertion.Subject.First();
            exception.Message.Should().Be($"Comment with id {commentId} does not exist");
        }
    }
}