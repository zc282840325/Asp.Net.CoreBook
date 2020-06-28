using Book.Core.IRepository.IBaseRepository;
using Book.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.IRepository
{
   public interface IRoleModulePermissionRepository:IBaseRepository<RoleModulePermission>
    {
        Task<List<RoleModulePermission>> RoleModuleMaps();
    }
}
