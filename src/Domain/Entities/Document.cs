using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    [Table("documents")]
    public class Document : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("CustomerID")]
        public string? CustomerId { get; set; }

        [Column("Name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Column("FileName")]
        [StringLength(100)]
        public string? FileName { get; set; }

        [Column("UploadedFileName")]
        [StringLength(100)]
        public string? UploadedFileName { get; set; }

        [Column("Size")]
        public long? Size { get; set; }

        [Column("UploadedBy")]
        public string? UploadedBy { get; set; }

        [Column("UploadedOn")]
        public DateTime? UploadedOn { get; set; }

        [Column("IsMigrated")]
        public bool? IsMigrated { get; set; }

        [Column("ErrorMessage", TypeName = "longtext")]
        public string? ErrorMessage { get; set; }
    }
}
