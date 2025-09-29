using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    [Table("benficiarydetail")]
    public class BeneficiaryDetail : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("CustomerID")]
        public string CustomerId { get; set; } = null!;

        [Column("Title")]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Column("FullName")]
        [StringLength(150)]
        public string FullName { get; set; } = null!;

        [Column("Gender")]
        [StringLength(1)]
        public string Gender { get; set; } = null!;

        [Column("NationalityID")]
        public int NationalityId { get; set; }

        [Column("Relationship")]
        [StringLength(100)]
        public string Relationship { get; set; } = null!;

        [Column("Address")]
        [StringLength(500)]
        public string Address { get; set; } = null!;

        [Column("City")]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Column("Postcode")]
        [StringLength(10)]
        public string Postcode { get; set; } = null!;

        [Column("State")]
        [StringLength(100)]
        public string State { get; set; } = null!;

        [Column("CountryID")]
        public int CountryId { get; set; }

        [Column("Email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column("Mobile")]
        [StringLength(20)]
        public string Mobile { get; set; } = null!;

        [Column("Telephone")]
        [StringLength(20)]
        public string? Telephone { get; set; }

        [Column("AccountName")]
        [StringLength(100)]
        public string AccountName { get; set; } = null!;

        [Column("AccountNumber")]
        [StringLength(50)]
        public string AccountNumber { get; set; } = null!;

        [Column("BankName")]
        [StringLength(50)]
        public string BankName { get; set; } = null!;

        [Column("BankBranch")]
        [StringLength(50)]
        public string BankBranch { get; set; } = null!;

        [Column("IFSCCODE")]
        [StringLength(50)]
        public string IfscCode { get; set; } = null!;

        [Column("BranchAddress")]
        [StringLength(500)]
        public string BranchAddress { get; set; } = null!;

        [Column("BankCity")]
        [StringLength(100)]
        public string BankCity { get; set; } = null!;

        [Column("BankPostcode")]
        [StringLength(100)]
        public string BankPostcode { get; set; } = null!;

        [Column("BankState")]
        [StringLength(100)]
        public string BankState { get; set; } = null!;

        [Column("BankCountryID")]
        public int BankCountryId { get; set; }

        [Column("Status")]
        public int Status { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("SwiftCode")]
        [StringLength(50)]
        public string? SwiftCode { get; set; }
    }
}
