using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Repositories
{
   public class ReaderRepository:BaseRepository<Reader>,IReaderRepository
    {
        public ReaderRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
