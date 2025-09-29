using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LotusFive.Domain.Common;

namespace LotusFive.Domain.Entities
{
    [Table("customerregistration")]
    public class CustomerRegistration : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("Title")]
        public string? Title { get; set; }

        [Column("CustomerType")]
        public string? CustomerType { get; set; }

        [Column("RegCompanyName")]
        public string? RegCompanyName { get; set; }

        [Column("RegCompanyNo")]
        public string? RegCompanyNo { get; set; }

        [Column("RegCompanyAddress", TypeName = "longtext")]
        public string? RegCompanyAddress { get; set; }

        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; } = null!;

        [Column("MiddleName")]
        public string? MiddleName { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("ResidentialStatus")]
        public string? ResidentialStatus { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("City")]
        public string? City { get; set; }

        [Column("State")]
        public string? State { get; set; }

        [Column("Postcode")]
        public string? Postcode { get; set; }

        [Column("CountryID")]
        public int? CountryId { get; set; }

        [Column("PermAddress")]
        public string? PermAddress { get; set; }

        [Column("PermCity")]
        public string? PermCity { get; set; }

        [Column("PermState")]
        public string? PermState { get; set; }

        [Column("PermPostcode")]
        public string? PermPostcode { get; set; }

        [Column("PermCountryID")]
        public int? PermCountryId { get; set; }

        [Column("CustomerNationalityID")]
        public int? CustomerNationalityId { get; set; }

        [Column("CustomerDOB")]
        public DateTime? CustomerDob { get; set; }

        [Column("CustomerProfession")]
        public string? CustomerProfession { get; set; }

        [Column("CustomerMobile")]
        public string? CustomerMobile { get; set; }

        [Column("CustomerPhone")]
        public string? CustomerPhone { get; set; }

        [Column("CustomerOfficeNo")]
        public string? CustomerOfficeNo { get; set; }

        [Column("CustomerEmail")]
        public string? CustomerEmail { get; set; }

        [Column("CustomerAlternateEmail")]
        public string? CustomerAlternateEmail { get; set; }

        [Column("Occupation")]
        public string? Occupation { get; set; }

        [Column("CompanyName")]
        public string? CompanyName { get; set; }

        [Column("CompanyAddress")]
        public string? CompanyAddress { get; set; }

        [Column("CompanyCity")]
        public string? CompanyCity { get; set; }

        [Column("CompanyState")]
        public string? CompanyState { get; set; }

        [Column("CompanyPostcode")]
        public string? CompanyPostcode { get; set; }

        [Column("CompanyCountryID")]
        public int? CompanyCountryId { get; set; }

        [Column("OLD_NRIC")]
        public string? OldNric { get; set; }

        [Column("NEW_NRIC")]
        public string? NewNric { get; set; }

        [Column("CustomerBankname")]
        public string? CustomerBankName { get; set; }

        [Column("CustomerAccNo", TypeName = "longtext")]
        public string? CustomerAccountNo { get; set; }

        [Column("PassportNumber", TypeName = "longtext")]
        public string? PassportNumber { get; set; }

        [Column("PassportIssuedCountryID")]
        public int? PassportIssuedCountryId { get; set; }

        [Column("PassportIssuedDate")]
        public DateTime? PassportIssuedDate { get; set; }

        [Column("PassportExpiryDate")]
        public DateTime? PassportExpiryDate { get; set; }

        [Column("VisaExpiryDate")]
        public DateTime? VisaExpiryDate { get; set; }

        [Column("ReferedBy")]
        public string? ReferredBy { get; set; }

        [Column("ReferedByMobile")]
        public string? ReferredByMobile { get; set; }

        [Column("ReferedByRelationship")]
        public string? ReferredByRelationship { get; set; }

        [Column("ReferedByEmail")]
        public string? ReferredByEmail { get; set; }

        [Column("ReferedByCompanyName")]
        public string? ReferredByCompanyName { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("Password")]
        public string? Password { get; set; }

        [Column("DateOfSignin")]
        public DateTime DateOfSignin { get; set; }

        [Column("LoyaltyID")]
        public string? LoyaltyId { get; set; }

        [Column("ApprovedBy")]
        public string? ApprovedBy { get; set; }

        [Column("RejectedBy")]
        public string? RejectedBy { get; set; }

        [Column("Remarks", TypeName = "longtext")]
        public string? Remarks { get; set; }

        [Column("NatureOfEntity")]
        public string? NatureOfEntity { get; set; }

        [Column("NatureOfBusiness")]
        public string? NatureOfBusiness { get; set; }

        [Column("NameOfDirector1")]
        public string? NameOfDirector1 { get; set; }

        [Column("NameOfDirector2")]
        public string? NameOfDirector2 { get; set; }

        [Column("NameOfDirector3")]
        public string? NameOfDirector3 { get; set; }

        [Column("TradeLicenseNumber")]
        public string? TradeLicenseNumber { get; set; }

        [Column("TradeLicenseIssueDate")]
        public DateTime? TradeLicenseIssueDate { get; set; }

        [Column("TradeLicenseExpiryDate")]
        public DateTime? TradeLicenseExpiryDate { get; set; }

        [Column("CustomerRegNo")]
        public string? CustomerRegNo { get; set; }

        [Column("UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [Column("ApprovalStage")]
        public int? ApprovalStage { get; set; }

        [Column("IsOfflineCustomer")]
        public bool? IsOfflineCustomer { get; set; }

        [Column("CardNo")]
        public string? CardNo { get; set; }

        [Column("Comments", TypeName = "longtext")]
        public string? Comments { get; set; }

        [Column("CreatedBy")]
        public string? CreatedBy { get; set; }

        [Column("ModifiedBy")]
        public string? ModifiedBy { get; set; }

        [Column("IsEmailChangeRequested")]
        public int? IsEmailChangeRequested { get; set; }

        [Column("IsGDPREnabled")]
        public int? IsGdprEnabled { get; set; }

        [Column("DocumentSubmitOption")]
        public int? DocumentSubmitOption { get; set; }

        [Column("SalesPersonId")]
        public string? SalesPersonId { get; set; }

        [Column("SessionKey")]
        public string? SessionKey { get; set; }

        [Column("SessionExpiry")]
        public DateTime? SessionExpiry { get; set; }

        [Column("Source")]
        public string? Source { get; set; }

        [Column("DeletedBy")]
        public string? DeletedBy { get; set; }

        [Column("DeletedOn")]
        public DateTime? DeletedOn { get; set; }

        [Column("EntrySourceId")]
        public int? EntrySourceId { get; set; }

        [Column("RefererNumber")]
        public string? RefererNumber { get; set; }

        [Column("RefererCampaignId")]
        public string? RefererCampaignId { get; set; }

        [Column("RefererEmailId")]
        public string? RefererEmailId { get; set; }

        [Column("PasswordCreatedDateTime")]
        public DateTime PasswordCreatedDateTime { get; set; }

        [Column("FailedLoginAttempts")]
        public int FailedLoginAttempts { get; set; }

        [Column("IsLocked")]
        public bool? IsLocked { get; set; }
    }
}
