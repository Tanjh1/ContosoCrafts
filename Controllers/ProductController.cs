using System.Collections.Generic;
using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public ProductController(JsonFileProductsService productService) =>
            ProductService = productService;

        public JsonFileProductsService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            if (request?.ProductId == null)
                return BadRequest();

            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string? ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
