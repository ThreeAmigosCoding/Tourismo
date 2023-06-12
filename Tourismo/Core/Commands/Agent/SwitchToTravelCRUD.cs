using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Client;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    class SwitchToTravelCRUD : CommandBase
    {
        private readonly TravelsOverviewViewModel _viewModel;

        public SwitchToTravelCRUD(TravelsOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.IsAgent)
            {
                string mode = (parameter as string)?.ToLower();
                GlobalStore.AddObject("TravelCRUDMode", mode);
                EventBus.FireEvent("SwitchToTravelCRUD");
            }
            
        }

    }
}
