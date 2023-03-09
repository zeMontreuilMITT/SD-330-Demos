using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Models;

namespace SD_330_Demos.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            // create a new up-to-date database with ONLY seeded values

            DemosContext context = new DemosContext(serviceProvider.GetRequiredService<DbContextOptions<DemosContext>>());

            // Initialization Strategy
            context.Database.EnsureDeleted();
            context.Database.Migrate();
                
            Address addressOne = new Address("123 Fake st", null, "Winnipeg", "Manitoba", "Canada");
            Address addressTwo = new Address("900 Pembina Ave", "Suite 300", "Winnipeg", "Manitoba", "Canada");
            Address addressThree = new Address("100 Henlow", null, "Saskatoon", "Saskatchewan", "Canada");

            if(!context.Address.Any())
            {
                context.Address.Add(addressOne);
                context.Address.Add(addressTwo);
                context.Address.Add(addressThree);
            }

            Customer customerOne = new Customer("Jane", "Doe", "Acme Inc", null);
            Customer customerTwo = new Customer("John", "Doe", "Anonymous Ltd.", "204-999-9999");

            if(!context.Customer.Any())
            {
                context.Customer.Add(customerOne);
                context.Customer.Add(customerTwo);
            }

            await context.SaveChangesAsync();

            // three different ways of setting up a many-to-many
            // add foreign keys to middle
            CustomerAddress caOne = new CustomerAddress();
            caOne.AddressId = addressOne.Id;
            caOne.CustomerId = customerOne.Id;

            // add outer object references to the middle
            CustomerAddress caTwo = new CustomerAddress();
            caTwo.Address = addressTwo;
            caTwo.Customer = customerOne;

            // add middle object to outer object references
            CustomerAddress caThree = new CustomerAddress();
            addressTwo.CustomerAddresses.Add(caThree);
            customerTwo.CustomerAddresses.Add(caThree);

            context.CustomerAddress.Add(caOne);
            context.CustomerAddress.Add(caTwo);
            context.CustomerAddress.Add(caThree);

            context.SaveChanges();
        }
    }
}
