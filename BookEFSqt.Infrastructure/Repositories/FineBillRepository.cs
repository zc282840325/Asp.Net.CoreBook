using System;
using System.Collections.Generic;
using System.Text;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookEFSqt.Infrastructure.Repositories
{
   public class FineBillRepository:BaseRepository<FineBill>, IFineBillRepository
    {
        public FineBillRepository(BookContext bookContext):base(bookContext)
        {

        }
    }
}
