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
                Transaction stat = _context.transactions.Where(c => c.Id == pay.StatusId).FirstOrDefault();
                stat.StatusCode = pay.StatusCode;
                _context.transactions.Update(stat);
                _context.SaveChanges();
           
                await _myhub.Clients.All.SendAsync(pay.StatusId.ToString(), pay.StatusId);

            }
            



        }
     

    }
}
