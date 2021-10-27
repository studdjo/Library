using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreID { get; set; }
        public string Label { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}