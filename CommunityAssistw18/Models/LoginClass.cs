using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistw18.Models
{
    public class LoginClass
    {
        public LoginClass() { }

        public LoginClass(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { set; get; }
        public string Password { set; get; }
    }
}