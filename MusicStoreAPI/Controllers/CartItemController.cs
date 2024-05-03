using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        [HttpGet("GetCartItems")]
        public IEnumerable<CartItem> Get()
        {
            var cartItems = new CartItemBD().Read();
            return cartItems;
        }

        [HttpPost("NewCartItem")]
        public void Post(int cart, int product, int quantity)
        {
            new CartItemBD().Create(cart, product, quantity);
        }

        [HttpPut("UpdateCartItem/{id}")]
        public void Put(int id, int cart, int product, int quantity)
        {
            new CartItemBD().UpdateCartItem(id, cart, product, quantity);
        }

        [HttpDelete("/Delete/{id}")]
        public void Delete(int id)
        {
            new CartItemBD().Delete(id);
        }
    }
}
