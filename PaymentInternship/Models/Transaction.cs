using System.ComponentModel.DataAnnotations;

namespace PaymentInternship.Models
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}
