using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Auth;

namespace Tourismo.Core.Commands.Auth
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel? _viewModel;
        public LoginCommand(LoginViewModel loginVM)
        {
            _viewModel = loginVM;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Email) || e.PropertyName == nameof(_viewModel.Password))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Email) && !string.IsNullOrEmpty(_viewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            User user = _viewModel.UserService.Authenticate(_viewModel.Email, _viewModel.Password);

            if (user == null)
            {
                _viewModel.ErrMsgText = "Email or password is incorrect!";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return;
            }

            MessageBox.Show("Login works!");
        }
    }
}
