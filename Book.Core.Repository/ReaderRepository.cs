using Book.Core.Entities;
using Book.Core.Repository.BaseRepository;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
   public class ReaderRepository:BaseRepository<Reader>,IReaderRepository
    {
        public ReaderRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
