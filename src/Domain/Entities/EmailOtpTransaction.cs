using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("email_otp_transaction")]
    public class EmailOtpTransaction
    {
        [Column("EmailId")]
        [MaxLength(200)]
        public string EmailId { get; set; } = null!;

        [Column("OTP")]
        [MaxLength(6)]
        public string Otp { get; set; } = null!;

        [Column("Status")]
        public int? Status { get; set; }

        [Column("ExpiryDate")]
        public DateTime? ExpiryDate { get; set; }
    }
}
