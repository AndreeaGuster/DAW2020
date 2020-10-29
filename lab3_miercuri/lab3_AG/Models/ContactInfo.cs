using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab3_AG.Models
{
    [Table("ContactsInfo")] // modifica numele tabelei din BD
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public string PhoneNumber { get; set; }

        // one to one
        [Required] // OBLIGATORIU !!!
        public virtual Publisher Publisher { get; set; }
    }
}