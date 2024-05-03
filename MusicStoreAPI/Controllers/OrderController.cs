using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet("GetOrders")]
        public IEnumerable<Order> Get()
        {
            var orders = new OrderBD().Read();
            return orders;
        }

        [HttpPost("NewOrder")]
        public void Post(int customer, int status, DateTime date)
        {
            new OrderBD().Create(customer, status, date);
        }

        [HttpPut("UpdateOrder/{id}")]
        public void Put(int id, int customer, int status, DateTime date)
        {
            new OrderBD().UpdateOrder(id, customer, status, date);
        }

        [HttpGet("GetOrdersByCustomer/{id}")]
        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
            var orders = new OrderBD().SearchByCustomer(id);
            return orders;
        }

        [HttpDelete("/{id}/Delete")]
        public void Delete(int id)
        {
            new OrderBD().Delete(id);
        }
    }
}
