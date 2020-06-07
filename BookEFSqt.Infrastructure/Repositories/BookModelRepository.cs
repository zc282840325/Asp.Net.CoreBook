using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookEFSqt.Infrastructure.Repositories
{
   public class BookModelRepository:BaseRepository<BookModel>, IBookModelRepository
    {
        public BookModelRepository(BookContext bookContext):base(bookContext)
        {

        }
        [Obsolete]
        public new async Task<List<BookModel>> Query()
        {
            return await _dbContext.Query<BookModel>().Include(x=>x.Tid).Include(x=>x.Pid).AsQueryable().ToListAsync();
        }
    }
}
