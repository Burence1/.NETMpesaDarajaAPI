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
        public string TransactionType { get; set; }

        [Required, StringLength(50)]
        public string TransID { get; set; }
        [Required]
        public DateTime TransTime { get; set; }

        [Required]
        [Column(TypeName = "Decimal (38,2)")]
        public string TransAmount { get; set; }
        [Required, StringLength(50)]
        public string BusinessShortCode { get; set; }
        [Required, StringLength(50)]
        public string BillRefNumber { get; set; }
        [Required]
        [Column(TypeName = "Decimal (38,2)")]
        public string OrgAccountBalance { get; set; }
        [Required, StringLength(50)]
        public string ThirdPartyTransID { get; set; }
        [Required, StringLength(50)]
        public string MSISDN { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string MiddleName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime created_at { get; set; }

        public MpesaTransaction()
        {
            created_at = DateTime.Now;
        }
    }
}
