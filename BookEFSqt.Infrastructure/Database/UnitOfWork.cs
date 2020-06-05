using Book.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookEFSqt.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _myContext;

        public UnitOfWork(BookContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<bool> SaveAsync()
        {
            return await _myContext.SaveChangesAsync() > 0;
        }
    }
}
