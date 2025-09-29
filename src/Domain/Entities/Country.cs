using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("country")]
    public class Country : IEntity<int>
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("CurrencyName")]
        public string? CurrencyName { get; set; }

        [Column("CurrencyCode")]
        public string? CurrencyCode { get; set; }

        [Column("FlagUnicode")]
        public string? FlagUnicode { get; set; }
    }
}
