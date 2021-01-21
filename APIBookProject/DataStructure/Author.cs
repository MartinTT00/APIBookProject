using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
     public  class Author:BaseModel
    {
        public int Age { get; set; }
        public int CountOfBooks { get; set; }

        public virtual List<Book> Books { get; set; }

        public virtual List<AuthorGenre> AuthorGenres { get; set; }

    }
}
