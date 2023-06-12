using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Client;

namespace Tourismo.Core.Commands.Agent
{
    class DeleteTravelCommand : CommandBase
    {
        private readonly TravelsOverviewViewModel _viewModel;

        public DeleteTravelCommand(TravelsOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Travel travel = (Travel)parameter;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this travel: "
                + travel.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                travel.IsActive = false;
                _viewModel.TravelService.Update(travel);
                _viewModel.Travels = _viewModel.TravelService.ReadAllActive().ToList();
                _viewModel.FilterItems();
                MessageBox.Show("Successfully deleted: " + travel.Name, "Success");
            }
        }
    }
}
