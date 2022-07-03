using Kolmeo.Products.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.Products.Repositories
{
    public interface IKolmeoDbContext : IDisposable
    {
        public DbSet<Product> Products { get; set; }

        public int SaveChanges();
    }
}