using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpGet("GetReviews")]
        public IEnumerable<Review> Get()
        {
            var reviews = new ReviewBD().Read();
            return reviews;
        }

        [HttpPost("NewReview")]
        public void Post(int customer, int product, int rating, string text)
        {
            new ReviewBD().Create(customer, product, rating, text);
        }

        [HttpPut("GetReviewsByProductId/{id}")]
        public List<Review>? GetReviewsByProductId(int id)
        {
            var reviews = new ReviewBD().SearchByProduct(id);
            return reviews;
        }

        [HttpPut("UpdateReview/{id}")]
        public void Put(int id, int customer, int product, int rating, string text)
        {
            new ReviewBD().UpdateReview(id, customer, product, rating, text);
        }

        [HttpDelete("/DeleteReview/{id}")]
        public void Delete(int id)
        {
            new ReviewBD().Delete(id);
        }
    }
}
