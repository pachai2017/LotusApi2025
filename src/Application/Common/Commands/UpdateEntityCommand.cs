using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Commands
{
    public record UpdateEntityCommand<TEntity, TKey>(TKey Id, TEntity Entity) : IRequest<TEntity?> where TEntity : class, IEntity<TKey>;

    public class UpdateEntityCommandHandler<TEntity, TKey> : IRequestHandler<UpdateEntityCommand<TEntity, TKey>, TEntity?> where TEntity : class, IEntity<TKey>
    {
        private readonly IAppDbContext _context;

        public UpdateEntityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Handle(UpdateEntityCommand<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var set = _context.Set<TEntity>();
            var existing = await set.FindAsync(new object?[] { request.Id }, cancellationToken);
            if (existing == null)
            {
                return null;
            }

            _context.Entry(existing).CurrentValues.SetValues(request.Entity);
            await _context.SaveChangesAsync(cancellationToken);
            return existing;
        }
    }
}
