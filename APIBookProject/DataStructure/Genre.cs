using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
     public class Genre:BaseModel
    {
        public virtual List<Book> Books { get; set; }
        public virtual List<AuthorGenre> AuthorGenres { get; set; }
    }
}
