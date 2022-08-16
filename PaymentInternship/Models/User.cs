using System.ComponentModel.DataAnnotations;

namespace PaymentInternship.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string RIbCode { get; set; } = string.Empty;
        public double Balance { get; set; } = 0.0;
    }
}
