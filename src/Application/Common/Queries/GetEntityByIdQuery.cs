using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Common.Queries
{
    public record GetEntityByIdQuery<TEntity, TKey>(TKey Id) : IRequest<TEntity?> where TEntity : class, IEntity<TKey>;

    public class GetEntityByIdQueryHandler<TEntity, TKey> : IRequestHandler<GetEntityByIdQuery<TEntity, TKey>, TEntity?> where TEntity : class, IEntity<TKey>
    {
        private readonly IAppDbContext _context;

        public GetEntityByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Handle(GetEntityByIdQuery<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<TEntity>().FindAsync(new object?[] { request.Id }, cancellationToken);
            return entity;
        }
    }
}
