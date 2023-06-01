using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Navigation
{
    public class ClientTravelsOverviewCommand : CommandBase
    {

        public ClientTravelsOverviewCommand() { }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("ClientTravelsOverview");
        }
    }
}
