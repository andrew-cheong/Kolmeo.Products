using Kolmeo.Products.Domain;
using Kolmeo.Products.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kolmeo.Products.WebApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        public IEnumerable<Product> List()
        {
            return _productService.GetAll();
        }

        /// <summary>
        /// Get a specific product
        /// </summary>
        /// <param name="productId">ID of product</param>
        /// <returns>Returns product</returns>
        [HttpGet("{productId}")]
        public Product Get(int productId)
        {
            return _productService.Get(productId);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productId">ID of product</param>
        [HttpPut]
        public int Add(string name, string description, decimal price)
        {
            return _productService.Add(name, description, price);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="productId">ID of product</param>
        [HttpPatch("{productId}")]
        public void Update(int productId, string name, string description, decimal price)
        {
            _productService.Update(productId, name, description, price);
        }

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="description">Description of product</param>
        /// <param name="minPrice">Min price of product</param>
        /// <param name="maxPrice">Max price of product</param>
        /// <returns>List of products</returns>
        [HttpGet("search")]
        public IList<Product> Search(string? name, string? description, decimal? minPrice, decimal? maxPrice)
        {
            return _productService.Search(name, description, minPrice, maxPrice);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId">ID of product to delete</param>
        [HttpDelete]
        public void Delete(int productId)
        {
            _productService.Delete(productId);
        }
    }
}
