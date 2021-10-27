using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int AuthorID { get; set; }

        //
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public ICollection<Borrow> Borrows { get; set; }

    }
}