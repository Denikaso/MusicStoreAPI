using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        [HttpGet("GetPayments")]
        public IEnumerable<Payment> Get()
        {
            var payments = new PaymentBD().Read();
            return payments;
        }

        [HttpPost("NewPayment")]
        public void Post(int order, double totalPrice, DateTime paymentDate, int paymentMethod)
        {
            new PaymentBD().Create(order, totalPrice, paymentDate, paymentMethod);
        }

        [HttpPut("UpdatePayment/{id}")]
        public void Put(int id, int order, double totalPrice, DateTime paymentDate, int paymentMethod)
        {
            new PaymentBD().UpdatePayment(id, order, totalPrice, paymentDate, paymentMethod);
        }

        [HttpDelete("/Delete/{id}")]
        public void Delete(int id)
        {
            new PaymentBD().Delete(id);
        }
    }
}
