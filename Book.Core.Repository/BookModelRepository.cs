using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Book.Core.Entities;
using Book.Core.IRepository;
using Book.Core.Repository.BaseRepository;
using Book.Core.EntityFramWork.Database;
using Microsoft.EntityFrameworkCore;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
    public class BookModelRepository:BaseRepository<BookModel>, IBookModelRepository
    {
        public BookModelRepository(BookContext bookContext) : base(bookContext)
        {

        }


        public async Task<List<BookModel>> Query1()
        {
            return await _dbContext.BookModels.Join(_dbContext.BookTypes, a => a.Tid, b => b.Tid, (a, b) => new { a, b }).Join(_dbContext.PublishingHouses, c => c.a.Pid, d => d.Pid, (c, d) => new { c, d }).Select(m=>new BookModel
            {
                Bid = m.c.a.Bid,
                BName=m.c.a.BName,
                TName=m.c.b.TName,
                PName=m.d.PName,
                Author = m.c.a.Author,
                Price = m.c.a.Price,
                PageNumber = m.c.a.PageNumber,
                TotalInventory = m.c.a.TotalInventory,
                ExistingStock = m.c.a.ExistingStock,
                StorageTime = m.c.a.StorageTime,
                OutNumbers = m.c.a.OutNumbers,
            }).AsQueryable().ToListAsync();
        }

        public void Check()
        {
            
        }
    }
}
