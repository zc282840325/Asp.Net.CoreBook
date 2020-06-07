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
            modelBuilder.Entity<BookModel>().ToTable("tb_Book");
            modelBuilder.Entity<FineBill>().ToTable("tb_FineBill");
            modelBuilder.Entity<BookStorage>().ToTable("tb_BookStorage");
            modelBuilder.Entity<BookStorageDetails>().ToTable("tb_BookStorageDetails");
            modelBuilder.Entity<BookDamaged>().ToTable("tb_BookDamaged");
            modelBuilder.Entity<BookDamagedDetails>().ToTable("tb_BookDamagedDetails");
            modelBuilder.Entity<Borrow>().ToTable("tb_Borrow");
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<ReaderType> ReaderTypes { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<FineBill> FineBills { get; set; }
        public DbSet<BookStorage> BookStorages { get; set; }
        public DbSet<BookStorageDetails> BookStorageDetailss { get; set; }
        public DbSet<BookDamaged> BookDamageds { get; set; }
        public DbSet<BookDamagedDetails> BookDamagedDetailss { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        
    }
}
