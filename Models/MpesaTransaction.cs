using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MpesaDarajaAPI.Models
{
    public class MpesaTransaction
    {
        [Key]
        public int id { get; set; }

        [Required,StringLength(50)]
        public string transactionType { get; set; }

        [Required, StringLength(50)]
        public string transactionId { get; set; }
        [Required]
        public DateTime transTime { get; set; }

        [Required]
        [Column(TypeName = "Decimal (38,2)")]
        public string transAmount { get; set; }
        [Required, StringLength(50)]
        public string businessShortCode { get; set; }
        [Required, StringLength(50)]
        public string billRefNumber { get; set; }
        [Required]
        [Column(TypeName = "Decimal (38,2)")]
        public string orgAccountBalance { get; set; }
        [Required, StringLength(50)]
        public string thirdPartyTransID { get; set; }
        [Required, StringLength(50)]
        public string MSISDN { get; set; }
        [Required, StringLength(50)]
        public string firstName { get; set; }
        [Required, StringLength(50)]
        public string middleName { get; set; }
        [Required, StringLength(50)]
        public string lastName { get; set; }
        [Required]
        public DateTime created_at { get; set; }

        [Required, StringLength(20)]
        public string responseCode { get; set; }

        public MpesaTransaction()
        {
            created_at = DateTime.Now;
        }
    }
}
