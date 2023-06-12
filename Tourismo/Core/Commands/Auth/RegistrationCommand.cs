using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Auth;

namespace Tourismo.Core.Commands.Auth
{
    public class RegistrationCommand : CommandBase
    {
        private readonly RegistrationViewModel? _viewModel;

        public RegistrationCommand(RegistrationViewModel? viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Name) || e.PropertyName == nameof(_viewModel.LastName) || e.PropertyName == nameof(_viewModel.Email) || e.PropertyName == nameof(_viewModel.Phone) || e.PropertyName == nameof(_viewModel.Password))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Name) && !string.IsNullOrEmpty(_viewModel.LastName) && ValidateEmail(_viewModel.Email) && ValidatePhoneNumber(_viewModel.Phone) && ValidatePassword(_viewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.UserService.Exists(_viewModel.Email))
            {
                MessageBox.Show("Sorry, that email is already in use. Use a different email to create your account.");
                return;
            }
            User user = _viewModel.UserService.Create(_viewModel.Email, _viewModel.Password, _viewModel.Name, _viewModel.LastName, Regex.Replace(_viewModel.Phone, @"[^0-9]", ""));
            MessageBox.Show("Welcome aboard! Your account has been created successfully.");
        }

        #region Validators

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                _viewModel.ErrMsgText = "Invalid email address.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            _viewModel.ErrMsgText = "";
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                _viewModel.ErrMsgText = "Password must be at least 8 characters long.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                _viewModel.ErrMsgText = "Password must contain at least one uppercase letter.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                _viewModel.ErrMsgText = "Password must contain at least one lowercase letter.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                _viewModel.ErrMsgText = "Password must contain at least one number.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            string specialCharacterPattern = @"[!@#$%^&*(),.?""':{}|<>]";
            if (!Regex.IsMatch(password, specialCharacterPattern))
            {
                _viewModel.ErrMsgText = "Password must contain at least one special character.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            _viewModel.ErrMsgText = "";
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            string digitsOnly = Regex.Replace(phoneNumber, @"[^0-9]", "");

            if (digitsOnly.Length < 8)
            {
                _viewModel.ErrMsgText = "Phone number must be at least 8 characters long.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            _viewModel.ErrMsgText = "";
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        #endregion
    }
}
