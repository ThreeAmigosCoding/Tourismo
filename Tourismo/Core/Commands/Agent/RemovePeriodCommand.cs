using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    class RemovePeriodCommand : CommandBase
    {
        private readonly TravelCRUDViewModel _viewModel;

        public RemovePeriodCommand(TravelCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedPeriod))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedPeriod != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Periods.Remove(_viewModel.SelectedPeriod);
            _viewModel.PeriodsLength = _viewModel.Periods.Count;
            _viewModel.SelectedPeriod = null;
        }


    }
}
