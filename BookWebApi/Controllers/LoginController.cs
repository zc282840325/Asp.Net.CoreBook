using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Book.Comment;
using Book.Comment.GlobalVars;
using Book.Comment.Helper;
using Book.Core;
using Book.Core.IRepository;
using Book.Core.IServices;
using Book.Core.Model;
using BookWebApi.AuthHelper.Policys;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        readonly ISysUserInfoServices _sysUserInfoServices;
        readonly IUserRoleRepository _userRoleRepository;
        readonly IRoleRepository _roleRepository;
        readonly PermissionRequirement _requirement;
        readonly IHttpContextAccessor _httpContext;
        private readonly IRoleModulePermissionRepository _roleModulePermissionRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="sysUserInfoServices"></param>
        /// <param name="userRoleServices"></param>
        /// <param name="roleServices"></param>
        /// <param name="requirement"></param>
        /// <param name="roleModulePermissionServices"></param>
        public LoginController(IHttpContextAccessor httpContext,ISysUserInfoServices sysUserInfoServices, IUserRoleRepository userRoleServices, IRoleRepository roleServices, PermissionRequirement requirement, IRoleModulePermissionRepository roleModulePermissionServices)
        {
            _httpContext = httpContext;
            this._sysUserInfoServices = sysUserInfoServices;
            this._userRoleRepository = userRoleServices;
            this._roleRepository = roleServices;
            _requirement = requirement;
            _roleModulePermissionRepository = roleModulePermissionServices;
        }

        /// <summary>
        /// 获取JWT的方法3：整个系统主要方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<MessageModel<TokenInfoViewModel>> Login([FromBody]LoginModel model)
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(model.LoginName) || string.IsNullOrEmpty(model.LoginPwd))
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "用户名或密码不能为空",
                };
            }

        //    pass = MD5Helper.MD5Encrypt32(pass);

            var user =await _sysUserInfoServices.Query(x=>x.uLoginName== model.LoginName&& x.uLoginPWD==model.LoginPwd && x.tdIsDelete==false);
            if (user.Count>0)
            {
                var userRoles = await _sysUserInfoServices.GetUserRoleNameStr(model.LoginName, model.LoginPwd);
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                //_requirement.Expiration.TotalSeconds
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, model.LoginName),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().uID.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(1).ToString()) };
                claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                var httpcontext = _httpContext.HttpContext;
                var claimsIdentity = new ClaimsIdentity("Cookie");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, user.FirstOrDefault().uID.ToString()));
                            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.FirstOrDefault().uRealName));
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                // ids4和jwt切换
                // jwt
                if (!Permissions.IsUseIds4)
                {
                    var data = await _roleModulePermissionRepository.RoleModuleMaps();
                    var list = (from item in data
                                where item.IsDeleted == false
                                orderby item.Id
                                select new PermissionItem
                                {
                                    Url = item.Module?.LinkUrl,
                                    Role = item.Role?.Name.ObjToString(),
                                }).ToList();

                    _requirement.Permissions = list;
                }

                var token = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = true,
                    msg = "获取成功",
                    response = token
                };
            }
            else
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "认证失败",
                };
            }
        }

        /// <summary>
        /// 请求刷新Token（以旧换新）
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<MessageModel<TokenInfoViewModel>> RefreshToken(string token = "")
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(token))
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "token无效，请重新登录！",
                };
            }
            var tokenModel = JwtHelper.SerializeJwt(token);
            if (tokenModel != null && tokenModel.Uid > 0)
            {
                var user= await _sysUserInfoServices.QueryById(int.Parse(tokenModel.Uid.ToString()));
                if (user != null)
                {
                    var userRoles = await _sysUserInfoServices.GetUserRoleNameStr(user.uLoginName, user.uLoginPWD);
                    //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.uLoginName),
                    new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid.ObjToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                    claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                    //用户标识
                    var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);

                    var refreshToken = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);
                    return new MessageModel<TokenInfoViewModel>()
                    {
                        success = true,
                        msg = "获取成功",
                        response = refreshToken
                    };
                }
            }

            return new MessageModel<TokenInfoViewModel>()
            {
                success = false,
                msg = "认证失败！",
            };
        }
    }
}