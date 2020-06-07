using System;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;


namespace BookEFSqt.Infrastructure.Repositories
{
   public class BookStorageDetailsRepository:BaseRepository<BookStorageDetails>,IBookStorageDetailsRepository
    {
        public BookStorageDetailsRepository(BookContext bookContext):base(bookContext)
        {

        }
      
    }
}
