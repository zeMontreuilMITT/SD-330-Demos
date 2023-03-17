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

        private void _createBlogModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.BlogAuthorizations);

            // ===== BLOG VALIDATION
            modelBuilder.Entity<Blog>()
                .Property(b => b.Title)
                .HasMaxLength(10)
                .IsRequired();


            //  ===== BLOG CONSTRAINTS
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.BlogNumber);

            // FK Blog to Journals
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Journals)
                .WithOne(j => j.Blog)
                .HasForeignKey(j => j.BlogNumber)
                .OnDelete(DeleteBehavior.Cascade);


            // Many to Many -- Blog to Author
            // Author has many BlogAuthorizations
            modelBuilder.Entity<Author>()
                .HasMany(a => a.AuthorizedBlogs)
                .WithOne(ab => ab.Author)
                .HasForeignKey(ab => ab.AuthorId);

            // Blog has many BlogAuthorizations
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.BlogAuthorizations)
                .WithOne(ab => ab.Blog)
                .HasForeignKey(ab => ab.BlogNumber);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _createBlogModel(modelBuilder);
           
        }

        public DbSet<Blog> Blog { get; set; } = default!;
        public DbSet<Journal> Journal { get; set; } = default!;
        public DbSet<Note> Note { get; set; } = default!;

        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<BlogAuthorization> BlogAuthorization { get; set; } = default!;
    }
}
