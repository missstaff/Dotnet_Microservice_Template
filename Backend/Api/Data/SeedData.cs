using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public static class SeedData
    {
        public static async Task InitializeDBAsync(ApiDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if Customers table is empty, if so then seed data
            if (!await context.Customers.AnyAsync())
            {
                await SeedCustomersAsync(context);
                await SeedDiscountsAsync(context);
            }
        }

        private static async Task SeedCustomersAsync(ApiDbContext context)
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Customer 1",
                    Insured = true,
                },
                new Customer
                {
                    Name = "Customer 2",
                    Insured = false,
                },
                new Customer
                {
                    Name = "Customer 3",
                    Insured = true,
                },
            };

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }

        private static async Task SeedDiscountsAsync(ApiDbContext context)
        {
            var discounts = new List<Discount>
            {
                new Discount
                {
                    Name = "Discount 1",
                    Percent = 0.5
                },
                new Discount
                {
                    Name = "Discount 2",
                    Percent = 0.25
                },
                new Discount
                {
                    Name = "Discount 3",
                    Percent = 0.75
                },
            };

            await context.Discounts.AddRangeAsync(discounts);
            await context.SaveChangesAsync();
        }
    }
}
