using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Commands.Auth;
using Tourismo.Core.Service.Interface.UserManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Auth
{
    public class LoginViewModel : ViewModelBase
    {

        private IUserService _userService;
        public IUserService UserService { get => _userService; }

        private string _email = "user1@example.com";
        public string Email
        {
            get => _email;
            set { 
                _email = value; 
                OnPropertyChanged(nameof(Email)); 
            }
        }

        private string _password = "password1";
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

        public ICommand? LoginRegisterSwitchCommand { get; }
        public ICommand? LoginCommand { get; }

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            _errMsgVisibility = Visibility.Hidden;
            _errMsgText = "";
            LoginRegisterSwitchCommand = new LoginRegisterSwitchCommand(this);
            LoginCommand = new LoginCommand(this);
        }

    }
}
