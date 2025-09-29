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
    public async Task GetAll_ShouldReturnOkWithEntities()
    {
        // Arrange
        var entities = new List<TestEntity> { new() { Id = 1, Name = "First" } };
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllEntitiesQuery<TestEntity>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entities);

        // Act
        var result = await _controller.GetAll(CancellationToken.None);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Which;
        okResult.Value.Should().BeEquivalentTo(entities);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenEntityIsMissing()
    {
        // Arrange
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetEntityByIdQuery<TestEntity, int>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((TestEntity?)null);

        // Act
        var result = await _controller.GetById(42, CancellationToken.None);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Update_ShouldReturnBadRequest_WhenIdDoesNotMatchEntity()
    {
        // Arrange
        var entity = new TestEntity { Id = 2, Name = "Mismatch" };

        // Act
        var result = await _controller.Update(1, entity, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BadRequestResult>();
        _mediatorMock.Verify(m => m.Send(It.IsAny<UpdateEntityCommand<TestEntity, int>>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Update_ShouldReturnOk_WhenMediatorReturnsEntity()
    {
        // Arrange
        var entity = new TestEntity { Id = 5, Name = "Updated" };
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateEntityCommand<TestEntity, int>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        // Act
        var result = await _controller.Update(entity.Id, entity, CancellationToken.None);

        // Assert
        result.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(entity);
    }

    [Fact]
    public async Task Delete_ShouldReturnNoContent_WhenMediatorConfirmsDeletion()
    {
        // Arrange
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteEntityCommand<TestEntity, int>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(10, CancellationToken.None);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    private sealed class TestEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    private sealed class TestEntityController : BaseEntityController<TestEntity, int>
    {
        public TestEntityController(IMediator mediator) : base(mediator)
        {
        }
    }
}
