using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.Common.Queries;

public class GetAllEntitiesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnEmptyCollection_WhenNoEntitiesExist()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new GetAllEntitiesQueryHandler<TestEntity>(context);

        var result = await handler.Handle(new GetAllEntitiesQuery<TestEntity>(), CancellationToken.None);

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_ShouldReturnAllEntities()
    {
        await using var context = TestAppDbContextFactory.Create();
        context.TestEntities.AddRange(
            new TestEntity { Id = 1, Name = "First" },
            new TestEntity { Id = 2, Name = "Second" });
        await context.SaveChangesAsync();
        var handler = new GetAllEntitiesQueryHandler<TestEntity>(context);

        var result = await handler.Handle(new GetAllEntitiesQuery<TestEntity>(), CancellationToken.None);

        result.Should().HaveCount(2);
        result.Select(e => e.Name).Should().BeEquivalentTo(new[] { "First", "Second" });
    }
}
