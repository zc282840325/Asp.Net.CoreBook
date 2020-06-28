using System;
using Book.Core.Entities;
using Book.Core.IRepository;
using Book.Core.Repository.BaseRepository;
using Book.Core.EntityFramWork.Database;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
   public class BookStorageDetailsRepository:BaseRepository<BookStorageDetails>,IBookStorageDetailsRepository
    {
        public BookStorageDetailsRepository(BookContext bookContext) : base(bookContext)
        { 
        }
      
    }
}
