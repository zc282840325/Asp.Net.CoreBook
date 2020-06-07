using System;
using System.Collections.Generic;
using System.Text;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;

namespace BookEFSqt.Infrastructure.Repositories
{
   public class BorrowRepository:BaseRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(BookContext bookContext):base(bookContext)
        {

        }
    }
}
