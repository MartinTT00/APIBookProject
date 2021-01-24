using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorGenre> AuthorGenres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }

        
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



            modelBuilder.Entity<BookLanguage>()
               .HasKey(x => new { x.BookID, x.LanguageID });
            modelBuilder.Entity<BookLanguage>()
                .HasOne(x => x.Book)
                .WithMany(x => x.BookLanguages)
                .HasForeignKey(x => x.BookID);
            modelBuilder.Entity<BookLanguage>()
                .HasOne(x => x.Language)
                .WithMany(x => x.BookLanguages)
                .HasForeignKey(x => x.LanguageID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }


}
