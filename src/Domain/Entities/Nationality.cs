using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("nationality")]
    public class Nationality : IEntity<int>
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }
    }
}
