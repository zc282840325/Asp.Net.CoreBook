using Book.Comment.Helper;
using Book.Core.IRepository;
using Book.Core.IServices;
using Book.Core.Model;
using Book.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Services
{
   public class SysUserInfoServices:BaseServices<sysUserInfo>, ISysUserInfoServices
    {
        public ISysUserInfoRepository _sysUserInfoReposity;
        public IRoleRepository _roleRepository;
        public IUserRoleRepository _userRoleRepository;

        public SysUserInfoServices(ISysUserInfoRepository sysUserInfoReposity, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _sysUserInfoReposity = sysUserInfoReposity;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            base.BaseDal = sysUserInfoReposity;
        }

        [Obsolete]
        public async Task<string> GetUserRoleNameStr(string uLoginName, string uLoginPWD)
        {
            string roleName = "";
            var user = (await base.Query(a => a.uLoginName == uLoginName && a.uLoginPWD == uLoginPWD)).FirstOrDefault();
            var roleList = await _roleRepository.Query(a => a.IsDeleted == false);
            if (user != null)
            {
                var userRoles = await _userRoleRepository.Query(ur => ur.UserId == user.uID);
                if (userRoles.Count > 0)
                {
                    var arr = userRoles.Select(ur => ur.RoleId.ObjToString()).ToList();
                    var roles = roleList.Where(d => arr.Contains(d.Id.ObjToString()));

                    roleName = string.Join(',', roles.Select(r => r.Name).ToArray());
                }
            }
            return roleName;
        }
     
    }
}
