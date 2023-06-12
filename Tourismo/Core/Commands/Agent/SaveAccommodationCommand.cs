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
    public class SaveAccommodationCommand : CommandBase
    {
        private readonly AccommodationCRUDViewModel? _viewModel;

        public SaveAccommodationCommand(AccommodationCRUDViewModel accommodationCRUDViewModel)
        {
            _viewModel = accommodationCRUDViewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.Accommodation.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Accommodation.Name) || e.PropertyName == nameof(_viewModel.Accommodation.Location.Address)
                || e.PropertyName == nameof(_viewModel.Accommodation.Price) || e.PropertyName == nameof(_viewModel.Accommodation.ImagePath))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Accommodation.Name) && !string.IsNullOrEmpty(_viewModel.Accommodation.Location.Address)
                && validatePrice() && validateImage() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {

            if (_viewModel.Mode == "create")
            {
                _viewModel.AccommodationService.Create(_viewModel.Accommodation);
                MessageBox.Show("Successfully created: " + _viewModel.Accommodation.Name, "Success");
                GlobalStore.AddObject("AccommodationCRUDMode", "create");
                EventBus.FireEvent("SwitchToAccommodationCRUD");
            }
            else
            {
                _viewModel.AccommodationService.Update(_viewModel.Accommodation);
                MessageBox.Show("Successfully updated: " + _viewModel.Accommodation.Name, "Success");
                EventBus.FireEvent("AgentAccommodationOverview");
            }

        }

        private bool validatePrice()
        {
            if (_viewModel.Accommodation.Price <= 0)
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
            if (string.IsNullOrEmpty(_viewModel.Accommodation.ImagePath))
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
