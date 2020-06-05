using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookEFSqt.Infrastructure.Repositories
{
    public class StaffRepository : BaseRepository<Staff>,IStaffRepository
    {
        public StaffRepository(BookContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
