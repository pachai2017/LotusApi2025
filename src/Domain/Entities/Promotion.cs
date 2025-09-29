using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("promotion")]
    public class Promotion : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Message", TypeName = "longtext")]
        public string? Message { get; set; }

        [Column("CreatedBy")]
        public string CreatedBy { get; set; } = null!;

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("ModifiedBy")]
        public string ModifiedBy { get; set; } = null!;

        [Column("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [Column("IsActive")]
        public bool? IsActive { get; set; }

        [Column("IsPopUp")]
        public bool? IsPopUp { get; set; }

        [Column("IsBanner")]
        public bool? IsBanner { get; set; }

        [Column("IsAdd")]
        public bool? IsAdd { get; set; }

        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }
    }
}
