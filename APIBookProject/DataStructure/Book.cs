using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Book : BaseModel
    {
        public int YearOfPublishment { get; set; }

        public virtual Author Author { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<BookLanguage> BookLanguages { get; set; }
    }
}
