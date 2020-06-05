using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Tools
{
    public class TokenPayload
    {
        public TokenPayload(int sid, string name, string role)
        {
            Sid = sid;
            Name = name;
            Role = role;
        }

        public int Sid { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
