using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BorrowBorrower
    {
        [Key, Column(Order = 1)]
        public int BorrowID { get; set; }

        [Key, Column(Order = 2)]
        public int BorrowerID { get; set; }

        public Borrow Borrow { get; set; }
        public Borrower Borrower { get; set; }
    }
}
