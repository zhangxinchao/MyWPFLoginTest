using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using LogIn.Annotations;

namespace LogIn
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserCredential _sapphireUser;
        private readonly UserCredential _momsUser;
        private  IList<ServiceConfig> _environments;

        public LoginViewModel()
        {
           
            _sapphireUser = new UserCredential();
            _momsUser = new UserCredential();
        }

        public IList<ServiceConfig> Environments
        {
            get { return _environments; }
            set { this._environments = value; }
        }
        public string SapphireUserName
        {
            get
            {
                return _sapphireUser.UserName;
            }
            set
            {
                _sapphireUser.UserName = value;
                OnPropertyChanged("SapphireUserName");
            }
        }

        public string SapphirePassword {
            get
            {
                return _sapphireUser.Password;
            }
            set
            {
                _sapphireUser.Password = value;
                
            } 
        }

        public string MomsUserName
        {
            get { return _momsUser.UserName; }
            set
            {
                _momsUser.UserName = value;
                OnPropertyChanged("MomsUserName"); }
        }

        public string MomsPassword
        {
            get
            {
                return _momsUser.Password;
            }
            set
            {
                _momsUser.Password = value;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Login { get { return new LoginCommand(_sapphireUser, _momsUser); } }

        public ServiceConfig ChoosenEnvironment
        {
            get { return _choosen; }
            set
            {
                _choosen = value;
                OnPropertyChanged("ChoosenEnvironment");
            }
        }

        private ServiceConfig _choosen;
    }
}