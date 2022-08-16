using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public virtual ICollection<Order> Orders { get; set; } =   new List<Order>();
    }
}
