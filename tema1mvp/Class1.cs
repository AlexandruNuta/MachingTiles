using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1mvp
{
    public class User
    {
        public string Username { get; set; }

        public string avatar{ get; set; }
    public User(string username,string avatar)
        {
            Username = username;
            this.avatar = avatar;
        }
    }
}

    
