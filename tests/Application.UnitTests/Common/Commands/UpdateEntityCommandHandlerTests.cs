using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.Common.Commands;

public class UpdateEntityCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnNull_WhenEntityIsMissing()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new UpdateEntityCommandHandler<TestEntity, int>(context);

        var result = await handler.Handle(new UpdateEntityCommand<TestEntity, int>(1, new TestEntity { Id = 1 }), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task Handle_ShouldUpdateAndReturnEntity_WhenFound()
    {
        await using var context = TestAppDbContextFactory.Create();
        context.TestEntities.Add(new TestEntity { Id = 5, Name = "Old" });
        await context.SaveChangesAsync();
        var handler = new UpdateEntityCommandHandler<TestEntity, int>(context);
        var updatedEntity = new TestEntity { Id = 5, Name = "Updated" };

        var result = await handler.Handle(new UpdateEntityCommand<TestEntity, int>(5, updatedEntity), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Updated");

        var stored = await context.TestEntities.AsNoTracking().SingleAsync();
        stored.Name.Should().Be("Updated");
    }
}
