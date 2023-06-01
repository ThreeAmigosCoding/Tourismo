using System.Windows;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Auth
{
    public class LogOutCommand : CommandBase
    {
        public LogOutCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                EventBus.FireEvent("GoToLogin");
            }
        }
    }
}
