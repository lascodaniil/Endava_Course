using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author auth;
    }
}