using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    public abstract class BaseEntityController<TEntity, TKey> : ControllerBase where TEntity : class, IEntity<TKey>
    {
        private readonly string _entityName;

        protected IMediator Mediator { get; }
        protected ILogger<BaseEntityController<TEntity, TKey>> Logger { get; }

        protected BaseEntityController(IMediator mediator, ILogger<BaseEntityController<TEntity, TKey>> logger)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _entityName = typeof(TEntity).Name;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Fetching all {EntityName} entities", _entityName);
            var result = await Mediator.Send(new GetAllEntitiesQuery<TEntity>(), cancellationToken);
            Logger.LogInformation("Successfully fetched all {EntityName} entities", _entityName);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(TKey id, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Fetching {EntityName} with id {EntityId}", _entityName, id);
            var entity = await Mediator.Send(new GetEntityByIdQuery<TEntity, TKey>(id), cancellationToken);
            if (entity == null)
            {
                Logger.LogWarning("{EntityName} with id {EntityId} was not found", _entityName, id);
                return NotFound();
            }

            Logger.LogInformation("Successfully fetched {EntityName} with id {EntityId}", _entityName, id);
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Creating a new {EntityName}", _entityName);
            var created = await Mediator.Send(new CreateEntityCommand<TEntity>(entity), cancellationToken);
            Logger.LogInformation("Successfully created {EntityName} with id {EntityId}", _entityName, GetEntityId(created));
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(created) }, created);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TEntity>> Update(TKey id, [FromBody] TEntity entity, CancellationToken cancellationToken)
        {
            if (!EqualityComparer<TKey>.Default.Equals(id, ((IEntity<TKey>)entity).Id))
            {
                Logger.LogWarning("Attempt to update {EntityName} with mismatched id. Route id: {RouteId}, Entity id: {EntityId}", _entityName, id, ((IEntity<TKey>)entity).Id);
                return BadRequest();
            }

            Logger.LogInformation("Updating {EntityName} with id {EntityId}", _entityName, id);
            var updated = await Mediator.Send(new UpdateEntityCommand<TEntity, TKey>(id, entity), cancellationToken);
            if (updated == null)
            {
                Logger.LogWarning("{EntityName} with id {EntityId} was not found for update", _entityName, id);
                return NotFound();
            }

            Logger.LogInformation("Successfully updated {EntityName} with id {EntityId}", _entityName, id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Deleting {EntityName} with id {EntityId}", _entityName, id);
            var deleted = await Mediator.Send(new DeleteEntityCommand<TEntity, TKey>(id), cancellationToken);
            if (!deleted)
            {
                Logger.LogWarning("{EntityName} with id {EntityId} was not found for deletion", _entityName, id);
                return NotFound();
            }

            Logger.LogInformation("Successfully deleted {EntityName} with id {EntityId}", _entityName, id);
            return NoContent();
        }

        protected virtual object? GetEntityId(TEntity entity)
        {
            return ((IEntity<TKey>)entity).Id;
        }
    }
}
