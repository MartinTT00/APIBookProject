using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructure;

namespace DataAccess.Repositories
{
    public class GenreRepository
    {
        private AppDbContext appDbContext;
        public GenreRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            genres = appDbContext.Genres.ToList();
            return genres;
        }


        public Genre PostGenre(Genre genre)
        {
            appDbContext.Genres.Add(genre);
            Save();
            return genre;
        }


        public void Save()
        {
            appDbContext.SaveChanges();
        }

        public Genre GetByID(int id)
        {
            Genre genre = new Genre();
            genre = appDbContext.Genres.Find(id);
            return genre;
        }



        public void PutGenre(Genre genre)
        {
            genre = GetByID(genre.ID);
            appDbContext.Genres.Update(genre);
            Save();
        }

        public void DeleteGenre(int id)
        {
            Genre genre = new Genre();
            genre = GetByID(id);
            appDbContext.Genres.Remove(genre);
            Save();

        }

    }
}
