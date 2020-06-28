using Book.Core.Entities;
using Book.Core.Repository.BaseRepository;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Book.Core.EntityFramWork;

namespace Book.Core.Repository
{
    public class StaffRepository : BaseRepository<Staff>,IStaffRepository
    {
        public StaffRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
