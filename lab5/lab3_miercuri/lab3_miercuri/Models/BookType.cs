using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab3_miercuri.Models
{
    public class BookType
    {
        public int BookTypeId { get; set; }

        [MinLength(2, ErrorMessage = "Book type name cannot be less than 2!"),
        MaxLength(20, ErrorMessage = "Book type name cannot be more than 20!")]
        public string Name { get; set; }

        // many to one
        public virtual ICollection<Book> Books { get; set; }
    }
}