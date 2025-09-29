using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Api.Controllers;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LotusFive.Api.ComponentTests.Controllers;

public class BaseEntityControllerTests
{
    private readonly Mock<IMediator> _mediatorMock = new();
    private readonly TestEntityController _controller;

    public BaseEntityControllerTests()
    {
        _controller = new TestEntityController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Update_ShouldReturnBadRequest_WhenIdMismatch()
    {
        // Arrange
        var entity = new TestEntity { Id = 2 };
        var id = 1;

        // Act
        var result = await _controller.Update(id, entity, CancellationToken.None);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task Update_ShouldReturnNotFound_WhenMediatorReturnsNull()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };
        var id = 1;

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<IRequest<TestEntity>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((TestEntity)null);

        // Act
        var result = await _controller.Update(id, entity, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Update_ShouldReturnOk_WhenMediatorReturnsEntity()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };
        var id = 1;

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<IRequest<TestEntity>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        // Act
        var result = await _controller.Update(id, entity, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(entity, okResult.Value);
    }

    // Supporting test entity & controller
    public class TestEntity : IEntity<int>
    {
        public int Id { get; set; }
    }

    public class TestEntityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestEntityController(IMediator mediator) => _mediator = mediator;

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TestEntity>> Update(int id, [FromBody] TestEntity entity, CancellationToken cancellationToken)
        {
            if (!EqualityComparer<int>.Default.Equals(id, ((IEntity<int>)entity).Id))
                return BadRequest();

            var updated = await _mediator.Send(new UpdateEntityCommand<TestEntity, int>(id, entity), cancellationToken);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
    }
}
