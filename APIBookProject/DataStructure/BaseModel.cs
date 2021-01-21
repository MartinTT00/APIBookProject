using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataStructure
{
    public class BaseModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }
    }
}
