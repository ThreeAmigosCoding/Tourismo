using System;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.UserManagement
{
    public class User : BaseObservableEntity
    {
        private string _emailAddress;
        public string EmailAddress { get => _emailAddress; set => OnPropertyChanged(ref _emailAddress, value); }

        private string _password;
        public string Password { get => _password; set => OnPropertyChanged(ref _password, value); }

        private string _firstName;
        public string FirstName { get => _firstName; set => OnPropertyChanged(ref _firstName, value); }

        private string _lastName;
        public string LastName { get => _lastName; set => OnPropertyChanged(ref _lastName, value); }

        private string _phone;
        public string Phone { get => _phone; set => OnPropertyChanged(ref _phone, value); }

        public string FullName => $"{_firstName} {_lastName}";

        private Role _role;
        public Role Role { get => _role; set => OnPropertyChanged(ref _role, value); }

    }
}
