using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusFive.Domain.Entities
{
    [Table("otptransaction")]
    public class OtpTransaction
    {
        [Column("MobileNo")]
        [MaxLength(20)]
        public string MobileNo { get; set; } = null!;

        [Column("OTP")]
        [MaxLength(6)]
        public string Otp { get; set; } = null!;

        [Column("Status")]
        public int? Status { get; set; }

        [Column("ExpiryDate")]
        public DateTime? ExpiryDate { get; set; }
    }
}
