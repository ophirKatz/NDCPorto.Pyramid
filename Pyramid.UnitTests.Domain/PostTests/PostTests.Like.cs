using System;
using Xunit;
using Pyramid.Domain;

namespace Pyramid.UnitTests.Domain.PostTests;

public partial class PostTests
{
    [Fact]
    public void ToggleLike_FirstTime_ShouldAddLiker()
    {
        var post = new Post(Guid.NewGuid(), "Some Content");
    }
}