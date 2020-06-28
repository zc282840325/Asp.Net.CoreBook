using System;
using System.Collections.Generic;
using System.Text;
using Book.Core.Entities;
using Book.Core.Repository.BaseRepository;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Database;
using Microsoft.EntityFrameworkCore;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
   public class FineBillRepository:BaseRepository<FineBill>, IFineBillRepository
    {
        public FineBillRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
