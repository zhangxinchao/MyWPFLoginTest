using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LogIn
{
    class LoginCommand : ICommand
    {
        private readonly IUserCredential _sapphireUser;
        private readonly IUserCredential _momsUser;

        private readonly IUserCredentialValidator _userValidator;
        public LoginCommand(IUserCredential sapphireUser, IUserCredential momsUser)
        {
            _sapphireUser = sapphireUser;
            _momsUser = momsUser;
        }
        public void Execute(object parameter)
        {
            var env = parameter as ServiceConfig;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
