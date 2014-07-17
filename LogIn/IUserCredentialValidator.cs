using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogIn
{
    interface IUserCredentialValidator
    {
        bool ValidateUserName(string name);

        bool ValidatePassword(string password);
    }
}
