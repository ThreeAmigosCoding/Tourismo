using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    class DeleteAttractionCommand : CommandBase
    {

        private AttractionsOverviewViewModel _viewModel;
        public DeleteAttractionCommand(AttractionsOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            TouristAttraction attraction = (TouristAttraction)parameter;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this attraction: "
                + attraction.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _viewModel.AttractionService.Deactivate(attraction);
                _viewModel.Attractions = _viewModel.AttractionService.ReadAllActive().ToList();
                _viewModel.FilterItems();
                MessageBox.Show("Successfully deleted: " + attraction.Name, "Success");
            }
        }

    }
}
