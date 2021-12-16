using Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    FirstName = "david",
                    LastName = "pop",
                    DateOfBirth = DateTimeOffset.Now
                });

                await context.SaveChangesAsync();
            }
        }
    }
}