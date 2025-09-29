using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("campaign")]
    public class Campaign : IEntity<string>
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; } = null!;

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Code")]
        public string? Code { get; set; }

        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [Column("Description", TypeName = "longtext")]
        public string? Description { get; set; }

        [Column("CreatedBy")]
        public string? CreatedBy { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("ModifiedBy")]
        public string? ModifiedBy { get; set; }

        [Column("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [Column("IsActive")]
        public bool? IsActive { get; set; }

        [Column("TransactionLimit")]
        public int? TransactionLimit { get; set; }
    }
}
