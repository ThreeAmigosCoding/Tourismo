using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class SaveTravelCommand : CommandBase
    {
        private TravelCRUDViewModel _viewModel;

        public SaveTravelCommand(TravelCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.Travel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.DefaultAttractionsDragDropViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Travel.Name) 
                || e.PropertyName == nameof(_viewModel.Travel.ShortDescription) 
                || e.PropertyName == nameof(_viewModel.Travel.ImagePath)
                || e.PropertyName == nameof(_viewModel.DefaultAttractionsDragDropViewModel.AttractionsLength)
                || e.PropertyName == nameof(_viewModel.SelectedAccommodation) 
                || e.PropertyName == nameof(_viewModel.PeriodsLength))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return validateName() 
                && validateDescription()
                && validateImage()
                && validateDefaultAttractions() 
                && validateAccommodation() 
                && validatePeriods() 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.Mode == "create")
            {
                Travel travel = new Travel
                {
                    Name = _viewModel.Travel.Name,
                    ShortDescription = _viewModel.Travel.ShortDescription,
                    ImagePath = _viewModel.Travel.ImagePath,
                    DefaultAttractions = _viewModel.DefaultAttractionsDragDropViewModel.Attractions.ToList(),
                    AdditionalAttractions = _viewModel.AdditionalAttractionsDragDropViewModel.Attractions.ToList(),
                    Accommodation = _viewModel.SelectedAccommodation,
                    Periods = _viewModel.Periods.ToList(),
                    MinimalPrice = _viewModel.DefaultAttractionsDragDropViewModel.Attractions.Sum(a => a.Price)
                };

                MessageBox.Show(travel.Periods[0].ToString());

                _viewModel.TravelService.Create(travel);
                MessageBox.Show("Successfully created: " + _viewModel.Travel.Name, "Success");
                GlobalStore.AddObject("TravelCRUDMode", "create");
                EventBus.FireEvent("SwitchToTravelCRUD");
            }
            else
            {

            }
        }

        private bool validateName()
        {
            if (string.IsNullOrEmpty(_viewModel.Travel.Name))
            {
                _viewModel.ErrMsgText = "Travel must contain a name.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool validateDescription()
        {
            if (string.IsNullOrEmpty(_viewModel.Travel.ShortDescription))
            {
                _viewModel.ErrMsgText = "Travel must contain a description.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool validateImage()
        {
            if (string.IsNullOrEmpty(_viewModel.Travel.ImagePath))
            {
                _viewModel.ErrMsgText = "Travel must contain an image.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

        private bool validateDefaultAttractions()
        {
            if (_viewModel.DefaultAttractionsDragDropViewModel.AttractionsLength > 0)
            {
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }
            _viewModel.ErrMsgText = "Travel must contain at least one default attraction.";
            _viewModel.ErrMsgVisibility = Visibility.Visible;
            return false;
        }

        private bool validateAccommodation()
        {
            if (_viewModel.SelectedAccommodation != null)
            {
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }
            _viewModel.ErrMsgText = "Travel must contain an accommodation.";
            _viewModel.ErrMsgVisibility = Visibility.Visible;
            return false;
        }

        private bool validatePeriods()
        {
            if (_viewModel.PeriodsLength > 0)
            {
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }
            _viewModel.ErrMsgText = "Travel must contain at least one available period.";
            _viewModel.ErrMsgVisibility = Visibility.Visible;
            return false;
        }

        
    }
}
