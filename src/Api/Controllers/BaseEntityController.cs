using System.Collections.Generic;
using Application.Common.Commands;
using Application.Common.Queries;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseEntityController<TEntity, TKey> : ControllerBase where TEntity : class, IEntity<TKey>
    {
        protected IMediator Mediator { get; }

        protected BaseEntityController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetAllEntitiesQuery<TEntity>(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(TKey id, CancellationToken cancellationToken)
        {
            var entity = await Mediator.Send(new GetEntityByIdQuery<TEntity, TKey>(id), cancellationToken);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity, CancellationToken cancellationToken)
        {
            var created = await Mediator.Send(new CreateEntityCommand<TEntity>(entity), cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(created) }, created);
        }

        protected virtual object? GetEntityId(TEntity entity)
        {
            return ((IEntity<TKey>)entity).Id;
        }
    }
}
