using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BookLanguage
    {
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public int LanguageID { get; set; }
        public virtual Language Language { get; set; }
    }
}
