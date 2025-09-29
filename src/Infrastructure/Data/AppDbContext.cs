using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Document> Documents => Set<Document>();
        public DbSet<BeneficiaryDetail> BeneficiaryDetails => Set<BeneficiaryDetail>();
        public DbSet<CustomerTransaction> CustomerTransactions => Set<CustomerTransaction>();
        public DbSet<CustomerRegistration> CustomerRegistrations => Set<CustomerRegistration>();
        public DbSet<CurrencyRate> CurrencyRates => Set<CurrencyRate>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Campaign> Campaigns => Set<Campaign>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<TransferFee> TransferFees => Set<TransferFee>();
        public DbSet<Promotion> Promotions => Set<Promotion>();
        public DbSet<OtpTransaction> OtpTransactions => Set<OtpTransaction>();
        public DbSet<Nationality> Nationalities => Set<Nationality>();
        public DbSet<FpxResponse> FpxResponses => Set<FpxResponse>();
        public DbSet<FpxConfiguration> FpxConfigurations => Set<FpxConfiguration>();
        public DbSet<FpxBank> FpxBanks => Set<FpxBank>();
        public DbSet<EntrySource> EntrySources => Set<EntrySource>();
        public DbSet<EmailOtpTransaction> EmailOtpTransactions => Set<EmailOtpTransaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OtpTransaction>().HasKey(x => new { x.MobileNo, x.Otp });
            modelBuilder.Entity<EmailOtpTransaction>().HasKey(x => new { x.EmailId, x.Otp });
        }
    }
}
