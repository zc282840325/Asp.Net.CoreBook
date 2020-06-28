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
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
