using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Language:BaseModel
    {
        public virtual List<BookLanguage> BookLanguages { get; set; }
    }
}
