using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
        public class SeedData
        {
                public static void SeedDatabase(DataContext context)
                {
                        context.Database.Migrate();

                        if (context.Products.Count() == 0 && context.Categories.Count() == 0)
                        {
                                Category fruits = new Category { Name = "fruits" };
                                Category shirts = new Category { Name = "shirts" };

                                context.Products.AddRange(
                                        new Product
                                        {
                                                Name = "Apples",
                                                Price = 1.50M,
                                                Category = fruits
                                        },
                                        new Product
                                        {
                                                Name = "Lemons",
                                                Price = 2M,
                                                Category = fruits
                                        },
                                        new Product
                                        {
                                                Name = "Watermelon",
                                                Price = 0.50M,
                                                Category = fruits
                                        },
                                        new Product
                                        {
                                                Name = "Grapefruit",
                                                Price = 2.50M,
                                                Category = fruits
                                        },
                                        new Product
                                        {
                                                Name = "Blue shirt",
                                                Price = 5.99M,
                                                Category = shirts
                                        },
                                        new Product
                                        {
                                                Name = "Black shirt",
                                                Price = 7.99M,
                                                Category = shirts
                                        },
                                        new Product
                                        {
                                                Name = "Red shirt",
                                                Price = 9.99M,
                                                Category = shirts
                                        },
                                        new Product
                                        {
                                                Name = "Yellow shirt",
                                                Price = 11.99M,
                                                Category = shirts
                                        }
                                );

                                context.SaveChanges();
                        }
                }
        }
}
