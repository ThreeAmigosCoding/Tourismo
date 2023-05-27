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
    public class RegistrationViewModel : ViewModelBase
    {
        #region Attributes

        private string _name;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _password;
        private string _errMsgText;
        private Visibility _errMsgVisibility;
        private IUserService _userService;

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
   
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrMsgText
        {
            get => _errMsgText;
            set
            {
                _errMsgText = value;
                OnPropertyChanged(nameof(ErrMsgText));
            }
        }

        public Visibility ErrMsgVisibility
        {
            get => _errMsgVisibility;
            set
            {
                _errMsgVisibility = value;
                OnPropertyChanged(nameof(ErrMsgVisibility));
            }
        }

        public IUserService UserService { get => _userService; }

        #endregion

        #region Commands

        public ICommand? LoginRegisterSwitchCommand { get; }
        public ICommand? RegistrationCommand { get; }

        #endregion

        public RegistrationViewModel(IUserService userService)
        {
            _userService = userService;
            _errMsgVisibility = Visibility.Hidden;
            _errMsgText = "";
            LoginRegisterSwitchCommand = new LoginRegisterSwitchCommand(this);
            RegistrationCommand = new RegistrationCommand(this);
        }

    }
}
