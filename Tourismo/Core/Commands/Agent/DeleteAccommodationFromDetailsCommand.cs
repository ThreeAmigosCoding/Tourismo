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
    internal class DeleteAccommodationFromDetailsCommand : CommandBase
    {
        private readonly AccommodationCRUDViewModel _viewModel;

        public DeleteAccommodationFromDetailsCommand (AccommodationCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.DeleteButtonVisibility == Visibility.Visible)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this accommodation: "
                + _viewModel.Accommodation.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.AccommodationService.Deactivate(_viewModel.Accommodation);
                    MessageBox.Show("Successfully deleted: " + _viewModel.Accommodation.Name, "Success");
                    EventBus.FireEvent("AgentAccommodationOverview");
                }
                
            }
            
        }
    }
}
