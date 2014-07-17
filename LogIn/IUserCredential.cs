using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogIn
{
    interface IUserCredential
    {
        string UserName { get;  }
        string Password { get;  }
    }
}
