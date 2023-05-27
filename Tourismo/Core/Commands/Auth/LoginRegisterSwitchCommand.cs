using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Auth;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Auth
{
    public class LoginRegisterSwitchCommand : CommandBase
    {   
        private readonly ViewModelBase? _viewModel;

        public LoginRegisterSwitchCommand(ViewModelBase? viewModel)
        {
            _viewModel = viewModel; 
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.GetType() == typeof(LoginViewModel))
            {
                EventBus.FireEvent("GoToRegistration");
            }
            else
            {
                EventBus.FireEvent("GoToLogin");
            }
        }
    }
}
