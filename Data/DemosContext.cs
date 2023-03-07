using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Models;

namespace SD_330_Demos.Data
{
    public class DemosContext : DbContext
    {
        public DemosContext(DbContextOptions<DemosContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<CustomerAddress> CustomerAddress { get; set; } = default!;
    }
}