using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Queries
{
    public record GetAllEntitiesQuery<TEntity>() : IRequest<IEnumerable<TEntity>> where TEntity : class;

    public class GetAllEntitiesQueryHandler<TEntity> : IRequestHandler<GetAllEntitiesQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {
        private readonly IAppDbContext _context;

        public GetAllEntitiesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> Handle(GetAllEntitiesQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
