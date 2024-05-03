using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        [HttpGet("GetCarts")]
        public IEnumerable<Cart> Get()
        {
            var carts = new CartBD().Read();
            return carts;
        }

        [HttpPost("NewCart")]
        public void Post(int customer, bool status, double totalPrice)
        {
            new CartBD().Create(customer, status, totalPrice);
        }

        [HttpPut("UpdateCart/{id}")]
        public void Put(int id, int customer, bool status, double totalPrice)
        {
            new CartBD().UpdateCart(id, customer, status, totalPrice);
        }

        [HttpDelete("/Delete/{id}")]
        public void Delete(int id)
        {
            new CartBD().Delete(id);
        }
    }
}
