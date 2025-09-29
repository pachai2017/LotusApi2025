using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Common.Interfaces;
using LotusFive.Domain.Entities;
using MediatR;

namespace LotusFive.Application.OtpTransactions.Queries
{
    public record GetOtpTransactionQuery(string MobileNo, string Otp) : IRequest<OtpTransaction?>;

    public class GetOtpTransactionQueryHandler : IRequestHandler<GetOtpTransactionQuery, OtpTransaction?>
    {
        private readonly IAppDbContext _context;

        public GetOtpTransactionQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<OtpTransaction?> Handle(GetOtpTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<OtpTransaction>().FindAsync(new object?[] { request.MobileNo, request.Otp }, cancellationToken);
        }
    }
}
