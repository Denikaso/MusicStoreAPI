using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : Controller
    {
        [HttpGet("GetSubcategories")]
        public IEnumerable<Subcategory> Get()
        {
            var subcategories = new SubcategoryBD().Read();
            return subcategories;
        }

        [HttpPost("NewSubcategory")]
        public void Post(string title, int category)
        {
            new SubcategoryBD().Create(title, category);
        }

        [HttpPut("UpdateSubcategory/{id}")]
        public void Put(int id, string title, int section)
        {
            new SubcategoryBD().UpdateSubcategory(id, title, section);
        }

        [HttpDelete("/Delete/{id}")]
        public void Delete(int id)
        {
            new SubcategoryBD().Delete(id);
        }

        [HttpGet("GetSubcategoriesByCategory/{categoryId}")]
        public List<Subcategory> GetSubcategoriesByCategory(int categoryId)
        {
            var subcategories = new SubcategoryBD().SearchByCategory(categoryId);
            return subcategories;
        }
    }
}
