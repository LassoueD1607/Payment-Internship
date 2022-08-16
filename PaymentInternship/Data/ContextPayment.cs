using Microsoft.EntityFrameworkCore;
using PaymentInternship.Models;

namespace PaymentInternship.Data
{
    public class ContextPayment:DbContext
    {
        public ContextPayment(DbContextOptions<ContextPayment> options):base(options)
        {
        }
        public DbSet<User> users { get; set; }
        
        public DbSet<Transaction> transactions { get; set; }

    }
}
