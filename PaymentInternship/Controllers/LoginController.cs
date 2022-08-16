using Microsoft.AspNetCore.Mvc;
using PaymentInternship.Data;
using PaymentInternship.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        static Login payment = new Login();
        private readonly ContextPayment _context;
        public static Response responseMessage = new Response();
        

        // GET: api/<LoginController>
        public LoginController(ContextPayment context)
        {
            _context = context;

        }
        [HttpGet]
        public Login Get()
        {
            return payment;
        }
        [HttpGet("Response")]

        public string GetResponse()
        {
            return responseMessage.ResponseMessage;
        }

        [HttpPost]
        public void Post([FromBody] Login pay)
        {
            bool changed = false;
            bool found = false;
            payment = pay;
            foreach (var customer in _context.users)
            {
                if (customer.PhoneNumber == pay.phoneNumber)
                {
                    found = true;
                    if (customer.Password == pay.password)
                    {
                        if (customer.Balance >= pay.Value)
                        {
                            customer.Balance = customer.Balance - pay.Value;
                            MerchantDetailsEndpointsClass.merchantDetails.Balance += pay.Value;
                            _context.users.Update(customer);
                            changed = true;
                        }
                        else
                        {
                            responseMessage.ResponseMessage = "Balance insufficent";
                        }
                    }
                    else { responseMessage.ResponseMessage = "Incorrect Password"; }
                }

            }
            if (changed)
            {
                _context.SaveChanges();
                responseMessage.ResponseMessage = "Valid";
            }
            if (!found)
            {
                responseMessage.ResponseMessage = "Invalid Customer";
            }



        }


    }
}
