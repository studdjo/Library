using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Borrow
    {
        [Key]
        public int BorrowID { get; set; }
        public DateTime StartOfBorrowing { get; set; }
        public DateTime EnfOfBorrowing { get; set; }
        public int BookID { get; set; }


        public Book Book { get; set; }
        public ICollection<Borrower> Borrows { get; set; }
    }
}
