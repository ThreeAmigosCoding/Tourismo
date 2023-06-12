using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    class SaveAttractionCommand : CommandBase
    {
        private AttractionCRUDViewModel _viewModel;
        public SaveAttractionCommand(AttractionCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.Attraction.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Attraction.Name) || e.PropertyName == nameof(_viewModel.Attraction.Location.Address)
                || e.PropertyName == nameof(_viewModel.Attraction.Price) || e.PropertyName == nameof(_viewModel.Attraction.ImagePath))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Attraction.Name) && !string.IsNullOrEmpty(_viewModel.Attraction.Location.Address)
                && validatePrice() && validateImage() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {

            if (_viewModel.Mode == "create")
            {
                _viewModel.AttractionService.Create(_viewModel.Attraction);
                MessageBox.Show("Successfully created: " + _viewModel.Attraction.Name, "Success");
                GlobalStore.AddObject("AttractionCRUDMode", "create");
                EventBus.FireEvent("SwitchToAttractionCRUD");
            }
            else
            {
                _viewModel.AttractionService.Update(_viewModel.Attraction);
                MessageBox.Show("Successfully updated: " + _viewModel.Attraction.Name, "Success");
                EventBus.FireEvent("AgentAttractionOverview");
            }
        }

        private bool validatePrice()
        {
            if (_viewModel.Attraction.Price <= 0)
            {
                _viewModel.ErrMsgText = "Price must be a positive number!";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool validateImage()
        {
            if (string.IsNullOrEmpty(_viewModel.Attraction.ImagePath))
            {
                _viewModel.ErrMsgText = "You must upload an image!";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }
    }
}
