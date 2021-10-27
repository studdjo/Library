using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    class DataContext : DbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Borrow> Borrows { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Borrower> Borrowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A9K2MCA; Database =Library; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
