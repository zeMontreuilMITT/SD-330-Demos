using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Models;

namespace SD_330_Demos.Data
{
    public class SD_330_DemosContext : DbContext
    {
        public SD_330_DemosContext (DbContextOptions<SD_330_DemosContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; } = default!;
        public DbSet<Journal> Journal { get; set; } = default!;
        public DbSet<Note> Note { get; set; } = default!;
    }
}
