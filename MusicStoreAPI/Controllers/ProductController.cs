using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;


namespace MusicStoreAPI.Controllers   
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet("GetProducts")]
        public IEnumerable<Product> Get()
        {
            var products = new ProductBD().Read();
            return products;
        }

        [HttpPost("NewProduct")]
        public void Post(int subcategory, string title, string description, double price, int unitsInCart, int unitsInStock, double rating, string picture)
        {
            new ProductBD().Create(subcategory, title, description, price, unitsInCart, unitsInStock, rating, picture);
        }

        [HttpPut("UpdateProduct/{id}")]
        public void Put(int id, int subcategory, string title, string description, double price, int unitsInCart, int unitsInStock, double rating, string picture)
        {
            new ProductBD().UpdateProduct(id, subcategory, title, description, price, unitsInCart, unitsInStock, rating, picture);
        }

        [HttpDelete("Product/{id}/Delete")]
        public void Delete(int id)
        {
            new ProductBD().Delete(id);
        }

        [HttpGet("GetProductsBySubcategory/{subcategoryId}")]
        public List<Product> GetProductsBySubcategory(int subcategoryId)
        {
            var products = new ProductBD().SearchBySubCategory(subcategoryId);
            return products;
        }

        [HttpGet("GetProductById/{Id}")]
        public Product? GetProductById(int Id)
        {
            var product = new ProductBD().SearchById(Id);
            return product;
        }
    }
}
