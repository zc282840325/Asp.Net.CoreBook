using Book.Core.IServices.Base;
using Book.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.IServices
{
   public interface ISysUserInfoServices: IBaseServices<sysUserInfo>
    {
        public Task<string> GetUserRoleNameStr(string uLoginName, string uLoginPWD);
    }
}
