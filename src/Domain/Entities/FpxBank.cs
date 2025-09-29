using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("fpxbank")]
    public class FpxBank : IEntity<int>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("EnvId")]
        public int? EnvId { get; set; }

        [Column("BankId")]
        public string? BankId { get; set; }

        [Column("BankName")]
        public string? BankName { get; set; }

        [Column("Sequence")]
        public int? Sequence { get; set; }
    }
}
