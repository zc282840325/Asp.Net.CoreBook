using Book.Comment;
using Book.Comment.Helper;
using Book.Core.EntityFramWork.Database;
using Book.Core.IRepository;
using Book.Core.Model;
using Book.Core.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Repository
{
   public class sysUserInfoRepository:BaseRepository<sysUserInfo>, ISysUserInfoRepository
    {
        public sysUserInfoRepository(BookContext book) : base(book)
        {
           
        }
   
    }
}
