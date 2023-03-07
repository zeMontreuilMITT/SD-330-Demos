using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Data;

namespace SD_330_Demos.Models
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            DemosContext context = new DemosContext(serviceProvider.GetRequiredService<DbContextOptions<DemosContext>>());

            if(!context.Address.Any())
            {
                context.Address.Add(new Address("123 Fake Street", null, "Winnipeg", "Manitoba", "Canada"));
                context.Address.Add(new Address("345 Fake Street", null, "Winnipeg", "Manitoba", "Canada"));
                context.Address.Add(new Address("9999 Fake Street", "101", "Winnipeg", "Manitoba", "Canada"));
            }

            await context.SaveChangesAsync();
           
        }
    }
}

/*
 * {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (!context.EntityOnes.Any())
            {
                
                context.EntityOnes.Add(new EntityOne());
                context.SaveChanges();
            }

            if(!context.TestModels.Any())
            {
                context.TestModels.Add(new TestModel { Name = "Gary blart" });
                context.SaveChanges();
            }
            await context.SaveChangesAsync();
        }
*/
