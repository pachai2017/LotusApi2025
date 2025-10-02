using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.Common.Queries;

public class GetEntityByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnNull_WhenEntityDoesNotExist()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new GetEntityByIdQueryHandler<TestEntity, int>(context);

        var result = await handler.Handle(new GetEntityByIdQuery<TestEntity, int>(123), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task Handle_ShouldReturnEntity_WhenFound()
    {
        await using var context = TestAppDbContextFactory.Create();
        context.TestEntities.Add(new TestEntity { Id = 7, Name = "Existing" });
        await context.SaveChangesAsync();
        var handler = new GetEntityByIdQueryHandler<TestEntity, int>(context);

        var result = await handler.Handle(new GetEntityByIdQuery<TestEntity, int>(7), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Existing");
    }
}
