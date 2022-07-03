using Kolmeo.Products.Domain;
using Kolmeo.Products.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kolmeo.Products.Bootstrapper
{
    public class DataSeeder
    {
        /// <summary>
        /// Seeds data in the in-memory EF database
        /// </summary>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<IKolmeoDbContext>())
            {
                if (context.Products.Any())
                {
                    // Already seeded, nothing to do here.
                    return;
                }

                var products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Corn Flakes",
                        Description = "Cereal",
                        Price = 2.98m
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "English Breakfast Tea",
                        Description = "Tea (pack of 100)",
                        Price = 6.37m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Chocolate Bar",
                        Description = "Nougat chocolate bar",
                        Price = 1.99m
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Milk",
                        Description = "Carton of milk 2L",
                        Price = 2.15m
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Honey",
                        Description = "Jar of honey",
                        Price = 3.89m
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Grapes",
                        Description = "Box of grapes",
                        Price = 5.55m
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Bread",
                        Description = "Load of bread",
                        Price = 1.80m
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Strawberry Jam",
                        Description = "Jar of strawberry jam",
                        Price = 2.50m
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "Hand Sanitiser",
                        Description = "Bottle of hand sanitiser",
                        Price = 4.23m
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Mince Beef",
                        Description = "Minced beef 500g",
                        Price = 4.58m
                    },
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}