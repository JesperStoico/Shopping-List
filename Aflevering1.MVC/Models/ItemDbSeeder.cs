using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Aflevering1.MVC.Models
{
    public class ItemDbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new ItemDbContext(serviceProvider.GetRequiredService<DbContextOptions<ItemDbContext>>());

            //Look for any shoppinglists
            if (context.Items.Any())
            {
                //if we get here then the data already seeded
                return;
            }

            context.Items.AddRange();
            context.Placements.AddRange(
            new Placement
            {
                Id = 1,
                Name= "Frugt og grønt",
            },
            new Placement
            {
                Id = 2,
                Name = "Mejeri",
            },
            new Placement
            {
                Id = 3,
                Name = "Brød",
            },
            new Placement
            {
                Id = 4,
                Name = "Konserves",
            },
            new Placement
            {
                Id = 5,
                Name = "Frost",
            }
            );
            context.Units.AddRange(
            new Unit
            {
                Id = 1,
                Name = "Kilo",
            },
            new Unit
            {
                Id = 2,
                Name = "Gram",
            },
            new Unit
            {
                Id = 3,
                Name = "Pakke",
            },
            new Unit
            {
                Id = 4,
                Name = "Pose",
            },
            new Unit
            {
                Id = 5,
                Name = "Liter",
            },
            new Unit
            {
                Id = 6,
                Name = "Mililiter",
            }
            );
            context.SaveChanges();
        }
    }
}
