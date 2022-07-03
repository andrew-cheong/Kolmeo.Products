using Kolmeo.Products.Domain;

namespace Kolmeo.Products.Services.Interfaces
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product Get(int productId);
        IList<Product> Search(string name, string description, decimal? minPrice, decimal? maxPrice);
        int Add(string name, string description, decimal price);
        void Update(int productId, string name, string description, decimal price);
        void Delete(int productId);
    }
}
