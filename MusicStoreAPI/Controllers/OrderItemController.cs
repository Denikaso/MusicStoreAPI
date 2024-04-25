using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : Controller
    {
        [HttpGet("GetOrderItems")]
        public IEnumerable<OrderItem> Get()
        {
            var cartItems = new OrderItemBD().Read();
            return cartItems;
        }

        [HttpPost("NewOrderItem")]
        public void Post(int order, int product, int quantity)
        {
            new OrderItemBD().Create(order, product, quantity);
        }

        [HttpPut("UpdateOrderItem/{id}")]
        public void Put(int id, int order, int product, int quantity)
        {
            new OrderItemBD().UpdateOrderItem(id, order, product, quantity);
        }

        [HttpDelete("OrderItem/{id}/Delete")]
        public void Delete(int id)
        {
            new OrderItemBD().Delete(id);
        }
    }
}
