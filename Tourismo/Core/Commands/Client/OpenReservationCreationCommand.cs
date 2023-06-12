using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Client;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Client
{
    public class OpenReservationCreationCommand : CommandBase
    {

        private TravelsOverviewViewModel _viewModel;

        public OpenReservationCreationCommand(TravelsOverviewViewModel viewModel) {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {

            EventBus.FireEvent("OpenReservationCreation", _viewModel.SelectedTravel);
        }
    }
}
