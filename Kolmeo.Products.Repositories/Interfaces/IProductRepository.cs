using Kolmeo.Products.Domain;

namespace Kolmeo.Products.Repositories.Interfaces
{
    public interface IProductRepository
    {
        int Add(string name, string description, decimal price);
        void Delete(int productId);
        Product Get(int productId);
        IList<Product> GetAll();
        IList<Product> Search(string name, string description, decimal? minPrice, decimal? maxPrice);
        void Update(int productId, string description, string name, decimal price);
    }
}
