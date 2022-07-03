using Kolmeo.Products.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kolmeo.Products.WebApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> List()
        {
            return new List<Product>();
        }

        [HttpGet("{productId}")]
        public Product Get(int productId)
        {
            return new Product();
        }

        [HttpPatch("{productId}")]
        public void Add(int productId)
        {

        }

        [HttpPost("{productId}")]
        public void Update(int productId)
        {

        }

        [HttpGet("Search")]
        public List<Product> Search(string? name, string? description, decimal? minPrice, decimal? maxPrice)
        {
            return new List<Product>();
        }
    }
}
