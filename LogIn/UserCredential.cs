using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogIn
{
    class UserCredential : IUserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
