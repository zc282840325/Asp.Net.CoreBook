using Book.Core.EntityFramWork.Database;
using Book.Core.IRepository;
using Book.Core.Model;
using Book.Core.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Repository
{
   public class RoleModulePermissionRepository:BaseRepository<RoleModulePermission>, IRoleModulePermissionRepository
    {
        public BookContext _book { get; set; }
        public RoleModulePermissionRepository(BookContext book):base(book)
        {
            _book = book;
        }
        /// <summary>
        /// 角色权限Map
        /// RoleModulePermission, Module, Role 三表联合
        /// 第四个类型 RoleModulePermission 是返回值
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleModulePermission>> RoleModuleMaps()
        {
            return await _book.RoleModulePermissions.
                Join(_dbContext.Modules,a=>a.ModuleId,b=>b.Id, (a,b)=> new {a,b}).
                Join(_dbContext.Roles,c=>c.a.RoleId,d=>d.Id, (c,d)=>new { c,d}).
                Where(x=>x.c.a.IsDeleted==false&&x.d.IsDeleted==false&&x.c.b.IsDeleted==false).
                Select(m=>new RoleModulePermission() {
                Role = m.d,
                Module = m.c.b,
                IsDeleted =m.c.a.IsDeleted
            }).AsQueryable().ToListAsync();
        }
    }
}
