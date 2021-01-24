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
    public class LanguageController : ControllerBase
    {
            private LanguageRepository languageRepository;
            public LanguageController(LanguageRepository languageRepository)
            {
                this.languageRepository = languageRepository;
            }

            [HttpGet("{id}", Name = "GetLanguageById")]
            public IActionResult GetByID(int id)
            {
                Language language = new Language();
                language = languageRepository.GetByID(id);
                return Ok(language);
            }

            [HttpPost]
            public IActionResult Post(Language language)
            {
                Uri uri = new Uri(Url.Link("GetLanguageByID", new { Id = language.ID }));
                language = languageRepository.PostLanguage(language);
                return Created(uri, language);
            }

            [HttpGet]
            public IActionResult Get()
            {
                List<Language> languages = languageRepository.GetLanguages();
                return Ok(languages);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Language language)
            {
                language = languageRepository.GetByID(id);
                languageRepository.PutLanguage(language);
                return Ok(language);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                languageRepository.DeleteLanguage(id);
                return Ok(id);
            }
        }
    }
}
