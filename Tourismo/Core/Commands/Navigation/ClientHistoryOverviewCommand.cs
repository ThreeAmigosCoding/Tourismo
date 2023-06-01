using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Navigation
{
    public class ClientHistoryOverviewCommand : CommandBase
    {

        public ClientHistoryOverviewCommand() { }

        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("ClientHistoryOverview");
        }
    }
}
