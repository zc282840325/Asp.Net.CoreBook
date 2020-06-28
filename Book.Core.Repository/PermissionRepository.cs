using Book.Core.EntityFramWork.Database;
using Book.Core.IRepository;
using Book.Core.Model;
using Book.Core.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Repository
{
   public class PermissionRepository:BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(BookContext bookContext):base(bookContext)
        {

        }
    }
}
