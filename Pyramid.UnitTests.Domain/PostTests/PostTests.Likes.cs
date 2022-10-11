using System;
using FluentAssertions;
using Xunit;
using Pyramid.Domain;

namespace Pyramid.UnitTests.Domain.PostTests;

public partial class PostTests
{
    [Fact]
    public void ToggleLike_FirstTime_ShouldAddLiker()
    {
        // Arrange
        var likerId = Guid.NewGuid();
        var post = new Post(Guid.NewGuid(), "Some Content");

        // Act
        post.ToggleLike(likerId);

        // Assert
        post.Likes.Should().Contain(likerId);
    }

    [Fact]
    public void ToggleLike_TwiceBySameLiker_ShouldContainNoLikes()
    {
        // Arrange
        var likerId = Guid.NewGuid();
        var post = new Post(Guid.NewGuid(), "Some Content");

        // Act
        post.ToggleLike(likerId);
        post.ToggleLike(likerId);

        // Assert
        post.Likes.Should().BeEmpty();
    }
}