using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    class SwitchToAccommodationCRUD : CommandBase
    {
        private AccommodationOverviewViewModel _viewModel;

        public SwitchToAccommodationCRUD (AccommodationOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            string mode = (parameter as string)?.ToLower();
            if (mode == "create")
            {
                GlobalStore.AddObject("AccommodationCRUDMode", mode);
            }
            else
            {
                GlobalStore.AddObject("AccommodationCRUDMode", mode);
            }

            EventBus.FireEvent("SwitchToAccommodationCRUD");
        }
    }
}
