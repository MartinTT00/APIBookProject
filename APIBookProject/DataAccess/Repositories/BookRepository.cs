using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructure;

namespace DataAccess.Repositories
{
    public class BookRepository
    {
        private AppDbContext appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }



        public void Save()
        {
            appDbContext.SaveChanges();
        }
        public Book GetByID(int id)
        {
            Book book = new Book();
            book = appDbContext.Books.Find(id);
            return book;
        }



        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            books = appDbContext.Books.ToList();
            return books;
        }

        public Book PostBook(Book book)
        {
            appDbContext.Books.Add(book);
            Save();
            return book;
        }

        public void PutBook(Book book)
        {
            book = GetByID(book.ID);
            appDbContext.Books.Update(book);
            Save();
        }

        public void DeleteBook(int id)
        {
            Book book = new Book();
            book = GetByID(id);
            appDbContext.Books.Remove(book);
            Save();

        }

    }
}
