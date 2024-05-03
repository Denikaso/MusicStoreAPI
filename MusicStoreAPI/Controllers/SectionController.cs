using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : Controller
    {
        [HttpGet("GetSections")]
        public IEnumerable<Section> Get()
        {
            var sections = new SectionBD().Read();
            return sections;
        }

        [HttpPost("NewSection")]
        public void Post(string title)
        {
            new SectionBD().Create(title);
        }

        [HttpPut("UpdateSection/{id}")]
        public void Put(int id, string title)
        {
            new SectionBD().UpdateSection(id, title);
        }

        [HttpDelete("/Delete/{id}")]
        public void Delete(int id)
        {
            new SectionBD().Delete(id);
        }
    }
}
