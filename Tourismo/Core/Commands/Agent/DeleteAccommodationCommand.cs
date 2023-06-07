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
    class DeleteAccommodationCommand : CommandBase
    {
        private AccommodationOverviewViewModel _viewModel;

        public DeleteAccommodationCommand(AccommodationOverviewViewModel overviewViewModel)
        {
            _viewModel = overviewViewModel;
        }

        public override void Execute(object? parameter)
        {
            Accommodation accommodation = (Accommodation)parameter;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this accommodation: " 
                + accommodation.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _viewModel.AccommodationService.Deactivate(accommodation);
                _viewModel.Accommodations = _viewModel.AccommodationService.ReadAllActive().ToList();
                _viewModel.FilterItems();
                MessageBox.Show("Successfully deleted: " + accommodation.Name, "Success");
            }

        }
    }
}
