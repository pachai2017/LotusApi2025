using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("currencyrate")]
    public class CurrencyRate : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("CountryID")]
        public int CountryId { get; set; }

        [Column("CountryName")]
        public string? CountryName { get; set; }

        [Column("Rate", TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

        [Column("WURate", TypeName = "decimal(18,2)")]
        public decimal? WuRate { get; set; }

        [Column("LotusRemitRate", TypeName = "decimal(18,2)")]
        public decimal? LotusRemitRate { get; set; }

        [Column("Buy", TypeName = "decimal(18,2)")]
        public decimal Buy { get; set; }

        [Column("Sell", TypeName = "decimal(18,2)")]
        public decimal Sell { get; set; }

        [Column("FlagName")]
        public string? FlagName { get; set; }

        [Column("CurrentDate")]
        public string? CurrentDate { get; set; }

        [Column("CurrentTime")]
        public string? CurrentTime { get; set; }

        [Column("ShortCurrencyCode")]
        public string ShortCurrencyCode { get; set; } = null!;

        [Column("TransferFee", TypeName = "decimal(18,2)")]
        public decimal TransferFee { get; set; }

        [Column("SEO_Remit_Button")]
        public string? SeoRemitButton { get; set; }
    }
}
