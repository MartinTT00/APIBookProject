using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructure;

namespace DataAccess.Repositories
{
    public class LanguageRepository
    {
        private AppDbContext appDbContext;
        public LanguageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }



        public void Save()
        {
            appDbContext.SaveChanges();
        }

        public Language GetByID(int id)
        {
            Language language = new Language();
            language = appDbContext.Languages.Find(id);
            return language;
        }



        public List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();
            languages = appDbContext.Languages.ToList();
            return languages;
        }

        public Language PostLanguage(Language language)
        {
            appDbContext.Languages.Add(language);
            Save();
            return language;
        }

        public void PutLanguage(Language language)
        {
            language = GetByID(language.ID);
            appDbContext.Languages.Update(language);
            Save();
        }

        public void DeleteLanguage(int id)
        {
            Language language = new Language();
            language = GetByID(id);
            appDbContext.Languages.Remove(language);
            Save();
        }

    }
}
