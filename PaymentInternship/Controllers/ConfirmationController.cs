using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PaymentInternship.Data;
using PaymentInternship.HubConfig;
using PaymentInternship.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationController : ControllerBase
    {

        static PaymentConfirmation paymentConfirmation;
        private readonly ContextPayment _context;
        private IHubContext<MyHub> _myhub;
        string connectionId;
        int timer = 100000000;

        public ConfirmationController(ContextPayment context, IHubContext<MyHub> myhub)
        {
            _context = context;

            _myhub = myhub;
           
            
        }

        // GET: api/<ConfirmationController>
        [HttpGet]
        public PaymentConfirmation Get()
        {
            return paymentConfirmation;
        }



        // POST api/<ConfirmationController>
        [HttpPost]
        public async void Post([FromBody] PaymentConfirmation pay)
        {
            paymentConfirmation = pay;
            if (pay.StatusCode == 1)
            {
                //Status stat = updateStatus(pay);
                Transaction stat = new Transaction();

                foreach (var transaction in _context.transactions)
                {
                    if (String.Equals(transaction.Id,pay.StatusId.ToString()))
                    {
                        stat = transaction;
                        stat.StatusCode = pay.StatusCode;
                    }
                }
                _context.transactions.Update(stat);
                _context.SaveChanges();
           
                await _myhub.Clients.User(connectionId).SendAsync("askServerResponse", pay.StatusId);
                
               







            }
            



        }
     

    }
}
