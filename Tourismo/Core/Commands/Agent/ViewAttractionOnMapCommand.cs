using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    internal class ViewAttractionOnMapCommand : CommandBase
    {

        private AttractionCRUDViewModel _viewModel;
        public ViewAttractionOnMapCommand(AttractionCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.Attraction.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.Attraction.Location.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Attraction.Location.Address))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Attraction.Location.Address);
        }

        public override async void Execute(object? parameter)
        {
            _viewModel.SelectedLocation = await MapUtils.GetLocationFromAddress(_viewModel.Attraction.Location.Address);

        }

    }
}
