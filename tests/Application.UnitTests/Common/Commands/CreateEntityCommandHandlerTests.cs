using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.Common.Commands;

public class CreateEntityCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddEntityToContext()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new CreateEntityCommandHandler<TestEntity>(context);
        var entity = new TestEntity { Id = 1, Name = "Created" };

        var result = await handler.Handle(new CreateEntityCommand<TestEntity>(entity), CancellationToken.None);

        result.Should().BeSameAs(entity);
        var stored = await context.TestEntities.SingleAsync();
        stored.Should().BeEquivalentTo(entity);
    }
}
