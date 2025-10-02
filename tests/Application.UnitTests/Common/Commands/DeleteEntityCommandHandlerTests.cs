using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.Common.Commands;

public class DeleteEntityCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnFalse_WhenEntityDoesNotExist()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new DeleteEntityCommandHandler<TestEntity, int>(context);

        var result = await handler.Handle(new DeleteEntityCommand<TestEntity, int>(1), CancellationToken.None);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Handle_ShouldRemoveEntity_WhenFound()
    {
        await using var context = TestAppDbContextFactory.Create();
        context.TestEntities.Add(new TestEntity { Id = 9, Name = "ToDelete" });
        await context.SaveChangesAsync();
        var handler = new DeleteEntityCommandHandler<TestEntity, int>(context);

        var result = await handler.Handle(new DeleteEntityCommand<TestEntity, int>(9), CancellationToken.None);

        result.Should().BeTrue();
        (await context.TestEntities.AnyAsync()).Should().BeFalse();
    }
}
