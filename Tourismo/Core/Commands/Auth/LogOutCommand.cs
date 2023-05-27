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
            EventBus.FireEvent("GoToLogin");
        }
    }
}
