using Book.Core.EntityFramWork.Database;
using Book.Core.IRepository;
using Book.Core.Model;
using Book.Core.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Repository
{
   public class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(BookContext book):base(book)
        {

        }
    }
}
