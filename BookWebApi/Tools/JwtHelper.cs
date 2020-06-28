using Book.Comment.Helper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookWebApi.Tools
{
    public class JwtHelper
    {
     
        public static string CreateToken(TokenPayload request)
        {
        
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Name),
                 new Claim(ClaimTypes.Role,request.Role),
               new Claim(ClaimTypes.Sid,request.Sid.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTStudyWebsite_DI20DXU3"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken("JWTStudy", "JWTStudyWebsite", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

           var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;

        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role;
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJwt
            {
                Uid = (jwtToken.Id).ObjToInt(),
                Role = role != null ? role.ObjToString() : "",
            };
            return tm;
        }
    }
    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModelJwt
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; }

    }
}
