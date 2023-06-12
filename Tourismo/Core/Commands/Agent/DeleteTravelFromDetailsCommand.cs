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

namespace Tourismo.Core.Commands.Agent
{
    class DeleteTravelFromDetailsCommand : CommandBase
    {

        private readonly TravelCRUDViewModel _viewModel;
        public DeleteTravelFromDetailsCommand(TravelCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.Mode != "create")
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this travel: "
                + _viewModel.Travel.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.Travel.IsActive = false;
                    _viewModel.TravelService.Update(_viewModel.Travel);
                    MessageBox.Show("Successfully deleted: " + _viewModel.Travel.Name, "Success");
                }

                EventBus.FireEvent("AgentTravelsOverview");
            }
        }
            
    }
}
