using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Common.Interfaces;
using LotusFive.Domain.Common;
using MediatR;

namespace LotusFive.Application.Common.Commands
{
    public record DeleteEntityCommand<TEntity, TKey>(TKey Id) : IRequest<bool> where TEntity : class, IEntity<TKey>;

    public class DeleteEntityCommandHandler<TEntity, TKey> : IRequestHandler<DeleteEntityCommand<TEntity, TKey>, bool> where TEntity : class, IEntity<TKey>
    {
        private readonly IAppDbContext _context;

        public DeleteEntityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEntityCommand<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var set = _context.Set<TEntity>();
            var entity = await set.FindAsync(new object?[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            set.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
