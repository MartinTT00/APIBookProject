using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructure;

namespace DataAccess.Repositories
{
    public class AuthorRepository
    {
        private AppDbContext appDbContext;
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

    }
}
