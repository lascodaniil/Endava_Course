using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Model.DTO
{
    public class BookViewModel
    {
        public Book book { get; set; }
        public List<Category> category { get; set; }
        public List<Publisher> publisher { get; set; }
        public List<Author> author { get; set; }
    }
}