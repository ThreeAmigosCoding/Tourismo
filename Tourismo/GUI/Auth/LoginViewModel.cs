using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Auth
{
    public class LoginViewModel : ViewModelBase
    {

        private string _email;
        public string Email
        {
            get => _email;
            set { 
                _email = value; 
                OnPropertyChanged(nameof(Email)); 
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _errMsgText;
        public string ErrMsgText
        {
            get => _errMsgText;
            set
            {
                _errMsgText = value;
                OnPropertyChanged(nameof(ErrMsgText));
            }
        }

        private Visibility _errMsgVisibility;
        public Visibility ErrMsgVisibility
        {
            get => _errMsgVisibility;
            set
            {
                _errMsgVisibility = value;
                OnPropertyChanged(nameof(ErrMsgVisibility));
            }
        }

        public LoginViewModel()
        {
            _errMsgVisibility = Visibility.Hidden;
            _errMsgText = "";
        }

    }
}
