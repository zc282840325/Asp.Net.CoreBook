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
    public class ReaderTypeRepository : BaseRepository<ReaderType>, IReaderTypeRepository
    {
        public ReaderTypeRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
