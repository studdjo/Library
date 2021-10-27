using System.Collections.Generic;
using System;

namespace Library.Models
{
    public class Borrower
    {
        public int BorrowerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public ICollection<Borrow> Borrows { get; set; }

    }
}