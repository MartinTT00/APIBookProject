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
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public AuthorController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public IActionResult GetByID(int id)
        {
            AuthorRepository authorRepository = new AuthorRepository(appDbContext);
            Author author = new Author();
            author = authorRepository.GetByID(id);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(Author author)
        {
            AuthorRepository authorRepository = new AuthorRepository(appDbContext);
            Uri uri = new Uri(Url.Link("GetAuthorByID", new { Id = author.ID }));
            author = authorRepository.PostAuthor(author);
            return Created(uri, author);
        }


        [HttpGet]
        public IActionResult Get()
        {
            AuthorRepository authorRepository = new AuthorRepository(appDbContext);
            List<Author> authors = authorRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Author author)
        {
            AuthorRepository authorRepository = new AuthorRepository(appDbContext);
            author = authorRepository.GetByID(id);
            authorRepository.PutAuthor(author);
            return Ok(author);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AuthorRepository authorRepository = new AuthorRepository(appDbContext);
            authorRepository.DeleteAuthor(id);
            return Ok(id);
        }

    }
}
