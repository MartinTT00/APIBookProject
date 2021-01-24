using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataStructure;
using DataAccess.Repositories;

namespace APIBookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private BookRepository bookRepository;
        public BookController(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public IActionResult GetByID(int id)
        {
            Book book = new Book();
            book = bookRepository.GetByID(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            Uri uri = new Uri(Url.Link("GetBookByID", new { Id = book.ID }));
            book = bookRepository.PostBook(book);
            return Created(uri, book);
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Book> books = bookRepository.GetBooks();
            return Ok(books);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            book = bookRepository.GetByID(id);
            bookRepository.PutBook(book);
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bookRepository.DeleteBook(id);
            return Ok(id);
        }
    }
}
