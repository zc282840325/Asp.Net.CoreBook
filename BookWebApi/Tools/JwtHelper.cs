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
    }
}
