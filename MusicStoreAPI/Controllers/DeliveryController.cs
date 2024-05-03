using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {
        [HttpGet("GetDeliveries")]
        public IEnumerable<Delivery> Get()
        {
            var deliveries = new DeliveryBD().Read();
            return deliveries;
        }

        [HttpPost("NewDelivery")]
        public void Post(int order, DateTime deliveryDate, string address, bool status, double price)
        {
            new DeliveryBD().Create(order, deliveryDate, address, status, price);
        }

        [HttpPut("UpdateDelivery/{id}")]
        public void Put(int id, int order, DateTime deliveryDate, string address, bool status, double price)
        {
            new DeliveryBD().UpdateDelivey(id, order, deliveryDate, address, status, price);
        }

        [HttpDelete("/DeleteDelivery/{id}")]
        public void Delete(int id)
        {
            new DeliveryBD().Delete(id);
        }
    }
}
