using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Commands
{
    public record CreateEntityCommand<TEntity>(TEntity Entity) : IRequest<TEntity> where TEntity : class;

    public class CreateEntityCommandHandler<TEntity> : IRequestHandler<CreateEntityCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IAppDbContext _context;

        public CreateEntityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Handle(CreateEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
