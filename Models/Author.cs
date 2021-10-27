using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string lastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
