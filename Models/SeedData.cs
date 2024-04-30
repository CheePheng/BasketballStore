using System;
using System.Linq;
using BasketballStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BasketballStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BasketballStoreContext(
                serviceProvider.GetRequiredService<DbContextOptions<BasketballStoreContext>>()))
            {
                if (context.Merch.Any())
                {
                    return;
                }

                context.Merch.AddRange(
                    new Merch
                    {
                        Name = "Basketball",
                        Description = "Official NBA basketball",
                        Price = 29.99
                    },
                    new Merch
                    {
                        Name = "Jersey",
                        Description = "Los Angeles Lakers jersey",
                        Price = 59.99
                    },
                    new Merch
                    {
                        Name = "Cap",
                        Description = "LA Clippers cap",
                        Price = 19.99
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
