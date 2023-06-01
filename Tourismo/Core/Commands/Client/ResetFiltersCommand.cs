using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Client;

namespace Tourismo.Core.Commands.Client
{
    public class ResetFiltersCommand : CommandBase
    {
        private readonly TravelsOverviewViewModel _viewModel;
        public ResetFiltersCommand(TravelsOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.FilteredTravels = new ObservableCollection<Travel>(_viewModel.Travels);
            _viewModel.MinPrice = "";
            _viewModel.MaxPrice = "";

            _viewModel.StartDate = null;
            _viewModel.EndDate = null;
            _viewModel.LowerBoundaryStart = DateTime.Now;
            _viewModel.LowerBoundaryEnd = _viewModel.LowerBoundaryStart.AddDays(1);
        }
    }
}
