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
        private AuthorRepository authorRepository;
        public AuthorController(AuthorRepository authorRepository)
        {
           this.authorRepository = authorRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Author> authors = authorRepository.GetAuthors();
            return Ok(authors);
        }
    }
}
