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
    public class GenreController : ControllerBase
    {
        private GenreRepository genreRepository;
        public GenreController(GenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        [HttpGet("{id}", Name = "GetGenreById")]
        public IActionResult GetByID(int id)
        {
            Genre genre = new Genre();
            genre = genreRepository.GetByID(id);
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            Uri uri = new Uri(Url.Link("GetGenreByID", new { Id = genre.ID }));
            genre = genreRepository.PostGenre(genre);
            return Created(uri, genre);
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Genre> genres = genreRepository.GetGenres();
            return Ok(genres);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Genre genre)
        {
            genre = genreRepository.GetByID(id);
            genreRepository.PutGenre(genre);
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            genreRepository.DeleteGenre(id);
            return Ok(id);
        }
    }
}
