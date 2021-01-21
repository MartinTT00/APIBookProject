using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class AuthorGenre
    {
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
