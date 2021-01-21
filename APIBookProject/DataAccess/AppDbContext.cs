using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorGenre> AuthorGenres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorGenre>()
                .HasKey(x => new { x.AuthorID, x.GenreID });
            modelBuilder.Entity<AuthorGenre>()
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorGenres)
                .HasForeignKey(x => x.AuthorID);
            modelBuilder.Entity<AuthorGenre>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.AuthorGenres)
                .HasForeignKey(x => x.GenreID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }


}
