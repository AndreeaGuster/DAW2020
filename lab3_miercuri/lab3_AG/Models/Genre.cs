using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab3_AG.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // many to many
        public virtual ICollection<Book> Books { get; set; }
    }
}