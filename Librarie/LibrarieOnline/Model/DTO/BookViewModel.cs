using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Model.DTO
{
    public class BookViewModel
    {
        //public Book book { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }


        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }


        public List<Category> category { get; set; }
        public List<Publisher> publisher { get; set; }
        public List<Author> author { get; set; }

    }
}