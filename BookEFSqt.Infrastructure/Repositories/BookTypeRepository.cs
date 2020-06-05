﻿using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Repositories
{
    public class BookTypeRepository : BaseRepository<BookType>, IBookTypeRepository
    {
        public BookTypeRepository(BookContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
