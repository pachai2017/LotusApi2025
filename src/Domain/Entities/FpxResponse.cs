using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("fpxresponse")]
    public class FpxResponse : IEntity<string>
    {
        [Key]
        [Column("Code")]
        [StringLength(3)]
        public string Id { get; set; } = null!;

        [Column("Description", TypeName = "longtext")]
        public string? Description { get; set; }
    }
}
