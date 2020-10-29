using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab3_AG.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }

        // one to many
        public virtual ICollection<Book> Books { get; set; }

        // one to one 
        public virtual ContactInfo ContactInfo { get; set; }
    }
}