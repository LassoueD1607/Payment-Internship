using System.ComponentModel.DataAnnotations;

namespace PaymentInternship.Models
{
    public class MerchantDetails
    {
        [Key]
        public int MerchantId { get; set; } = 1;
        public string MerchantName { get; set; } = "MS SOLUTION";
        public string Password { get; set; } = "123";
        public string PhoneNumber { get; set; } = "22222222";
        public string BankName { get; set; } = "ATB";
        public string RIB { get; set; } = "55552222";
        public double Balance { get; set; } = 0.0;

        public string getMerchantRIB()
        {
            return RIB;
        }
    }
}

