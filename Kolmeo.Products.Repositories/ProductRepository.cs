using Kolmeo.Products.Domain;
using Kolmeo.Products.Repositories.Interfaces;

namespace Kolmeo.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IKolmeoDbContext _context;

        public ProductRepository(IKolmeoDbContext context)
        {
            _context = context;
        }

        public IList<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Get(int productId)
        {
            return _context.Products.FirstOrDefault(u => u.Id == productId);
        }

        public IList<Product> Search(string name, string description, decimal? minPrice, decimal? maxPrice)
        {
            IQueryable<Product> productsQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                productsQuery = productsQuery.Where(u => u.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(description))
                productsQuery = productsQuery.Where(u => u.Description.Contains(description, StringComparison.InvariantCultureIgnoreCase));

            if (minPrice != null)
                productsQuery = productsQuery.Where(u => u.Price >= minPrice);

            if (maxPrice != null)
                productsQuery = productsQuery.Where(u => u.Price <= maxPrice);

            return productsQuery.ToList();
        }

        public int Add(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description), "Description cannot be null or empty.");

            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), price, "Price must be greater than zero.");

            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public void Update(int productId, string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description), "Description cannot be null or empty.");

            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), price, "Price must be greater than zero.");

            Product product = Get(productId);

            if (product != null)
            {
                product.Name = name;
                product.Description = description;
                product.Price = price;

                _context.SaveChanges();
            }
        }

        public void Delete(int productId)
        {
            Product product = Get(productId);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
