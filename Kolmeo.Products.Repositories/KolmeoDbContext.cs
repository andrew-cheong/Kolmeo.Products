using Kolmeo.Products.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.Products.Repositories
{
    public class KolmeoDbContext : DbContext, IKolmeoDbContext
    {
        public KolmeoDbContext(DbContextOptions<KolmeoDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}