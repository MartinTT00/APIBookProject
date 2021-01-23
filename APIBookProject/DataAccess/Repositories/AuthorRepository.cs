using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructure;

namespace DataAccess.Repositories
{
    public class AuthorRepository
    {
        private readonly AppDbContext appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            authors = appDbContext.Authors.ToList();
            return authors;
        }


        public Author PostAuthor(Author author)
        {
            appDbContext.Authors.Add(author);
            Save();
            return author;
        }



        public void Save()
        {
            appDbContext.SaveChanges();
        }

        public Author GetByID(int id)
        {
            Author author = new Author();
            author = appDbContext.Authors.Find(id);
            return author;
        }



        public void PutAuthor(Author author)
        {
            author = GetByID(author.ID);
            appDbContext.Authors.Update(author);
            Save();
        }

        public void DeleteAuthor(int id)
        {
            Author author = new Author();
            author = GetByID(id);
            appDbContext.Authors.Remove(author);
            Save();
 
        }

    }
}
