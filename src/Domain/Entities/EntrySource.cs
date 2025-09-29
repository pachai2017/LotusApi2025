using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("entrysource")]
    public class EntrySource : IEntity<int>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("IsNotifyEnabled")]
        public bool IsNotifyEnabled { get; set; }
    }
}
