using Kolmeo.Products.Domain;
using Kolmeo.Products.Repositories.Interfaces;
using Kolmeo.Products.Services.Interfaces;

namespace Kolmeo.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int Add(string name, string description, decimal price)
        {
            return _productRepository.Add(name, description, price);
        }

        public void Delete(int productId)
        {
            _productRepository.Delete(productId);
        }

        public Product Get(int productId)
        {
            return _productRepository.Get(productId);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IList<Product> Search(string name, string description, decimal? minPrice, decimal? maxPrice)
        {
            return _productRepository.Search(name, description, minPrice, maxPrice);
        }

        public void Update(int productId, string name, string description, decimal price)
        {
            _productRepository.Update(productId, name, description, price);
        }
    }
}
