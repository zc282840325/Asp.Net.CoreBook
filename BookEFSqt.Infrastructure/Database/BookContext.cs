using Book.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Database
{
   public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Staff>().ToTable("tb_Staff");
            modelBuilder.Entity<PublishingHouse>().ToTable("tb_PublishingHouse");
            modelBuilder.Entity<BookType>().ToTable("tb_BookType");
            modelBuilder.Entity<ReaderType>().ToTable("tb_ReaderType");
            modelBuilder.Entity<Reader>().ToTable("tb_Reader");
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<ReaderType> ReaderTypes { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
