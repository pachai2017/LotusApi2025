using LotusApi2025.Domain.Entities;
using Xunit;

namespace Domain.Tests;

public class UserTests
{
    [Fact]
    public void CanInstantiateUser()
    {
        var user = new User { Id = 1, Name = "Alice" };
        Assert.Equal(1, user.Id);
        Assert.Equal("Alice", user.Name);
    }
}
