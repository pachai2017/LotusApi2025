using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    [Table("customertransaction")]
    public class CustomerTransaction : IEntity<string>
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; } = null!;

        [Column("TypeOfTransfer")]
        public string? TypeOfTransfer { get; set; }

        [Column("DateOfTransfer")]
        public DateTime? DateOfTransfer { get; set; }

        [Column("CustomerID")]
        public string CustomerId { get; set; } = null!;

        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        [Column("BenficiaryID")]
        public string? BeneficiaryId { get; set; }

        [Column("RemittanceFee", TypeName = "decimal(18,2)")]
        public decimal? RemittanceFee { get; set; }

        [Column("ExchangeRate", TypeName = "decimal(18,2)")]
        public decimal? ExchangeRate { get; set; }

        [Column("TransferTo")]
        public int? TransferTo { get; set; }

        [Column("TransferToCurrency")]
        public string? TransferToCurrency { get; set; }

        [Column("NetPay", TypeName = "decimal(18,2)")]
        public decimal? NetPay { get; set; }

        [Column("NetPayOut", TypeName = "decimal(18,2)")]
        public decimal? NetPayOut { get; set; }

        [Column("NomineeName")]
        public string? NomineeName { get; set; }

        [Column("NomineeRelation")]
        public string? NomineeRelation { get; set; }

        [Column("NomineePassport")]
        public string? NomineePassport { get; set; }

        [Column("NomineeAccNo")]
        public string? NomineeAccNo { get; set; }

        [Column("NomineeBankname")]
        public string? NomineeBankName { get; set; }

        [Column("SourceOfFunds", TypeName = "longtext")]
        public string? SourceOfFunds { get; set; }

        [Column("PurposeOfTransfer", TypeName = "longtext")]
        public string? PurposeOfTransfer { get; set; }

        [Column("ReferenceNo")]
        public string? ReferenceNo { get; set; }

        [Column("ModeOfTransfer")]
        public string? ModeOfTransfer { get; set; }

        [Column("BankAccno")]
        public string? BankAccNo { get; set; }

        [Column("BankName")]
        public string? BankName { get; set; }

        [Column("TransactionDate")]
        public string? TransactionDate { get; set; }

        [Column("TransactionAmount", TypeName = "decimal(18,2)")]
        public decimal? TransactionAmount { get; set; }

        [Column("TransactionNo")]
        public string? TransactionNo { get; set; }

        [Column("ReceiptFileName")]
        public string? ReceiptFileName { get; set; }

        [Column("StatusToCustomer")]
        public int? StatusToCustomer { get; set; }

        [Column("StatusToAdmin")]
        public int? StatusToAdmin { get; set; }

        [Column("SellerOrderNo")]
        public string? SellerOrderNo { get; set; }

        [Column("ResponseStatus")]
        public string? ResponseStatus { get; set; }

        [Column("MESG_TYPE")]
        public string? MessageType { get; set; }

        [Column("MESG_TOKEN")]
        public string? MessageToken { get; set; }

        [Column("FPX_TXN_ID")]
        public string? FpxTransactionId { get; set; }

        [Column("SELLER_EX_DESC")]
        public string? SellerExDescription { get; set; }

        [Column("SELLER_EX_ID")]
        public string? SellerExId { get; set; }

        [Column("ORDER_NO")]
        public string? OrderNo { get; set; }

        [Column("NO_OF_ORDERS")]
        public string? NumberOfOrders { get; set; }

        [Column("TXN_TIME")]
        public string? TransactionTime { get; set; }

        [Column("SELLER_TXN_TIME")]
        public string? SellerTransactionTime { get; set; }

        [Column("ORDER_LIST")]
        public string? OrderList { get; set; }

        [Column("SLNO")]
        public string? SerialNo { get; set; }

        [Column("SELLER")]
        public string? Seller { get; set; }

        [Column("SELLER_ORDER_NO")]
        public string? SellerOrderNoAlt { get; set; }

        [Column("SELLER_ID")]
        public string? SellerId { get; set; }

        [Column("BUYER")]
        public string? Buyer { get; set; }

        [Column("BUYER_BANK")]
        public string? BuyerBank { get; set; }

        [Column("BUYER_BANK_BRANCH")]
        public string? BuyerBankBranch { get; set; }

        [Column("BUYER_BANK_FULLNAME")]
        public string? BuyerBankFullName { get; set; }

        [Column("BUYER_ACC_NO")]
        public string? BuyerAccountNo { get; set; }

        [Column("BUYER_NAME")]
        public string? BuyerName { get; set; }

        [Column("BUYER_ID")]
        public string? BuyerId { get; set; }

        [Column("MAKER_NAME")]
        public string? MakerName { get; set; }

        [Column("BUYER_IBAN")]
        public string? BuyerIban { get; set; }

        [Column("CHARGE_TYPE")]
        public string? ChargeType { get; set; }

        [Column("TXN_CCY")]
        public string? TransactionCurrency { get; set; }

        [Column("TXN_AMT")]
        public string? TransactionAmountRaw { get; set; }

        [Column("DEBIT_AUTH_CODE")]
        public string? DebitAuthCode { get; set; }

        [Column("DEBIT_AUTH_NO")]
        public string? DebitAuthNo { get; set; }

        [Column("CREDIT_AUTH_CODE")]
        public string? CreditAuthCode { get; set; }

        [Column("CREDIT_AUTH_NO")]
        public string? CreditAuthNo { get; set; }

        [Column("CHKSUM", TypeName = "longtext")]
        public string? Checksum { get; set; }

        [Column("VoucherNo")]
        public string? VoucherNo { get; set; }

        [Column("IsCompleted")]
        public bool? IsCompleted { get; set; }

        [Column("LotusStatus")]
        public string? LotusStatus { get; set; }

        [Column("GSTRate", TypeName = "decimal(18,2)")]
        public decimal? GstRate { get; set; }

        [Column("GSTAmount", TypeName = "decimal(18,2)")]
        public decimal? GstAmount { get; set; }

        [Column("FPX_REQUEST", TypeName = "longtext")]
        public string? FpxRequest { get; set; }

        [Column("FPX_RESPONSE", TypeName = "longtext")]
        public string? FpxResponse { get; set; }

        [Column("RetryCount")]
        public int? RetryCount { get; set; }

        [Column("FPX_ERROR_CODE", TypeName = "longtext")]
        public string? FpxErrorCode { get; set; }

        [Column("FPX_ERROR_MESSAGE", TypeName = "longtext")]
        public string? FpxErrorMessage { get; set; }

        [Column("ThreadStatus")]
        public string? ThreadStatus { get; set; }

        [Column("LastAccessDate")]
        public DateTime? LastAccessDate { get; set; }

        [Column("NextRetryDate")]
        public DateTime? NextRetryDate { get; set; }

        [Column("IsOfflineTransaction")]
        public bool? IsOfflineTransaction { get; set; }

        [Column("CreatedBy")]
        public string? CreatedBy { get; set; }

        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        [Column("UpdatedBy")]
        public string? UpdatedBy { get; set; }

        [Column("UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [Column("OfflineReciptName")]
        public string? OfflineReceiptName { get; set; }

        [Column("OfflineReciptActualName")]
        public string? OfflineReceiptActualName { get; set; }

        [Column("OfflineDocumentName")]
        public string? OfflineDocumentName { get; set; }

        [Column("OfflineDocumentActualName")]
        public string? OfflineDocumentActualName { get; set; }

        [Column("OfflineRemarks")]
        public string? OfflineRemarks { get; set; }

        [Column("ServiceTypeId")]
        public string? ServiceTypeId { get; set; }

        [Column("FPX_RESULT", TypeName = "longtext")]
        public string? FpxResult { get; set; }

        [Column("BuyerBankId", TypeName = "longtext")]
        public string? BuyerBankId { get; set; }

        [Column("UserCampaignId")]
        public string? UserCampaignId { get; set; }

        [Column("IpAddress")]
        public string? IpAddress { get; set; }

        [Column("Source")]
        public string? Source { get; set; }

        [Column("IsReceiptEmailSent")]
        public bool? IsReceiptEmailSent { get; set; }

        [Column("EntrySourceId")]
        public int? EntrySourceId { get; set; }

        [Column("CustomerComments")]
        public string? CustomerComments { get; set; }
    }
}
