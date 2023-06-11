using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Navigation
{
    public class AgentArrangementForTravelCommand : CommandBase
    {
        private readonly ReportsOverviewViewModel _reportsOverviewViewModel;

        public AgentArrangementForTravelCommand (ReportsOverviewViewModel reportsOverviewViewModel)
        {
            _reportsOverviewViewModel = reportsOverviewViewModel;
        }

        public override void Execute(object? parameter)
        {
            GlobalStore.AddObject("ArrangementTravel", parameter);
            EventBus.FireEvent("SwitchToArrangementsForTravel");
        }
    }
}
