using Book.Core.Entities;
using Book.Core.Repository.BaseRepository;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Database;
using Book.Core.EntityFramWork.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
    public class BookTypeRepository : BaseRepository<BookType>, IBookTypeRepository
    {
        public BookTypeRepository(BookContext bookContext) : base(bookContext)
        {

        }

        [Obsolete]
        public async Task<List<BookTypeDto>> Query()
        {
            return await _dbContext.BookTypes.Join(_dbContext.Librarys, a => a.LibraryNumber, b => b.Lid, (a, b) => new { a, b }).Select(m => new BookTypeDto { }).AsQueryable().ToListAsync();
           
            //  return await _dbContext.Query<BookModel>().Include(x => x.BookTypes).Include(X => X.PublishingHouses).Select((BookModel) => { }).AsQueryable().ToListAsync();

            //Bid = m.c.a.Bid,
            //    Author = m.c.a.Author,
            //    Price = m.c.a.Price,
            //    PageNumber = m.c.a.PageNumber,
            //    TotalInventory = m.c.a.TotalInventory,
            //    ExistingStock = m.c.a.ExistingStock,
            //    StorageTime = m.c.a.StorageTime,
            //    OutNumbers = m.c.a.OutNumbers,
            //}
        }
    }
}
