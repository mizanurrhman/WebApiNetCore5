using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDotNetCoreWithUnitTest.Data.Models;

namespace WebApiDotNetCoreWithUnitTest.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                    .HasOne(b => b.Book)
                    .WithMany(ba => ba.BookAuthors)
                    .HasForeignKey(bi => bi.BookId);


            modelBuilder.Entity<BookAuthor>()
                    .HasOne(b => b.Author)
                    .WithMany(ba => ba.BookAuthors)
                    .HasForeignKey(bi => bi.AuthorId);

            modelBuilder.Entity<Log>().HasKey(n => n.Id);
        }
        public DbSet<Book> Books { get; set; } // Book is class and Books is database class
        public DbSet<Author> Authors { get; set; } 
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Log> Logs { get; set; }




    }
}
