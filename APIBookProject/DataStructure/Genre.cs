using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
     public class Genre:BaseModel
    {
        public List<Book> Books { get; set; }
    }
}
