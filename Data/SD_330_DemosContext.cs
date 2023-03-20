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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify the discriminators for each parent class
            modelBuilder.Entity<Media>()
                .HasDiscriminator<string>("media_type")
                .HasValue<Song>("media_song")
                .HasValue<Episode>("media_episode");

            modelBuilder.Entity<MediaCollection>()
                .HasDiscriminator<string>("mcollection_type")
                .HasValue<Album>("mcollection_album")
                .HasValue<Podcast>("mcollection_podcast");

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.MediaCollectionId);

            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Podcast)
                .WithMany(p => p.Episodes)
                .HasForeignKey(e => e.MediaCollectionId);
        }

        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Episode> Episode { get; set;} = default!;
        public DbSet<Podcast> Podcast { get; set; } = default!;
    }
}
