using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Book : BaseModel
    {
        public int YearOfPublishment { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
