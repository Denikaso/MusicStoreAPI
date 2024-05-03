using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : Controller
    {
        [HttpGet("GetSupplies")]
        public IEnumerable<Supply> Get()
        {
            var supplies = new SupplyBD().Read();
            return supplies;
        }

        [HttpPost("NewSupply")]
        public void Post(int supplier, int product, double pricePerUnit, int quantity)
        {
            new SupplyBD().Create(supplier, product, pricePerUnit, quantity);
        }

        [HttpPut("UpdateSupply/{id}")]
        public void Put(int id, int supplier, int product, double pricePerUnit, int quantity)
        {
            new SupplyBD().UpdateSupply(id, supplier, product, pricePerUnit, quantity);
        }

        [HttpDelete("/DeleteSupply/{id}")]
        public void Delete(int id)
        {
            new SupplyBD().Delete(id);
        }
    }
}
