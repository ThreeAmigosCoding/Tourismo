using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    class AddPeriodCommand : CommandBase
    {
        private readonly TravelCRUDViewModel _viewModel;

        public AddPeriodCommand(TravelCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.StartDate) || e.PropertyName == nameof(_viewModel.EndDate))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.StartDate != null && _viewModel.EndDate != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            DateRange dateRange = new DateRange
            {
                StartDate = (DateTime)_viewModel.StartDate,
                EndDate = (DateTime)_viewModel.EndDate
            };
            _viewModel.Periods.Add(dateRange);
            var sortedPeriods = _viewModel.Periods.OrderBy(p => p.StartDate);
            _viewModel.Periods = new ObservableCollection<DateRange>(sortedPeriods);
            _viewModel.PeriodsLength = _viewModel.Periods.Count;
            _viewModel.StartDate = null;
            _viewModel.EndDate = null;
            _viewModel.SelectedPeriod = null;
        }

        
    }
}
