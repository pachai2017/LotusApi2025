using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("transferfee")]
    public class TransferFee : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("CountryID")]
        public int CountryId { get; set; }

        [Column("Fee", TypeName = "decimal(18,2)")]
        public decimal FeeAmount { get; set; }

        [Column("FlagName")]
        public string? FlagName { get; set; }

        [Column("ShortCurrencyCode")]
        public string ShortCurrencyCode { get; set; } = null!;
    }
}
