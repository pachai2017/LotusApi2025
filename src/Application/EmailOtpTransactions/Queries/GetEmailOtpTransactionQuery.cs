using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.EmailOtpTransactions.Queries
{
    public record GetEmailOtpTransactionQuery(string EmailId, string Otp) : IRequest<EmailOtpTransaction?>;

    public class GetEmailOtpTransactionQueryHandler : IRequestHandler<GetEmailOtpTransactionQuery, EmailOtpTransaction?>
    {
        private readonly IAppDbContext _context;

        public GetEmailOtpTransactionQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailOtpTransaction?> Handle(GetEmailOtpTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<EmailOtpTransaction>().FindAsync(new object?[] { request.EmailId, request.Otp }, cancellationToken);
        }
    }
}
