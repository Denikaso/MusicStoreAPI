using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpGet("GetCategories")]
        public IEnumerable<Category> Get()
        {
            var categories = new CategoryBD().Read();
            return categories;
        }

        [HttpPost("NewCategory")]
        public void Post(string title, int section)
        {
            new CategoryBD().Create(title, section);
        }

        [HttpPut("UpdateCategory/{id}")]
        public void Put(int id, string title, int section)
        {
            new CategoryBD().UpdateCategory(id, title, section);
        }

        [HttpDelete("Category/{id}/Delete")]
        public void Delete(int id)
        {
            new CategoryBD().Delete(id);
        }
    }
}
