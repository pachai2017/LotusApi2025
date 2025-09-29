using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("fpxconfiguration")]
    public class FpxConfiguration : IEntity<int>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Environment")]
        public string? Environment { get; set; }

        [Column("CertPath")]
        public string? CertPath { get; set; }

        [Column("SellerExId")]
        public string? SellerExId { get; set; }

        [Column("SellerId")]
        public string? SellerId { get; set; }

        [Column("SellerBankCode")]
        public string? SellerBankCode { get; set; }

        [Column("CurrencyCode")]
        public string? CurrencyCode { get; set; }

        [Column("BuyerBankId")]
        public string? BuyerBankId { get; set; }

        [Column("productDescription", TypeName = "longtext")]
        public string? ProductDescription { get; set; }

        [Column("FpxVersion")]
        public string? FpxVersion { get; set; }

        [Column("FPX_URL", TypeName = "longtext")]
        public string? FpxUrl { get; set; }

        [Column("DailyTransactionLimit", TypeName = "decimal(16,2)")]
        public decimal? DailyTransactionLimit { get; set; }

        [Column("SingleTransactionLimit", TypeName = "decimal(16,2)")]
        public decimal? SingleTransactionLimit { get; set; }
    }
}
