using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("branch")]
    public class Branch : IEntity<string>
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; } = null!;

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Address", TypeName = "longtext")]
        public string? Address { get; set; }

        [Column("ContactNo")]
        public string? ContactNo { get; set; }

        [Column("IsSiteContact")]
        public bool? IsSiteContact { get; set; }

        [Column("Timings")]
        public string? Timings { get; set; }
    }
}
