using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Utility;
using Tourismo.GUI.Client;

namespace Tourismo.Core.Commands.Client
{
    public class ApplyFiltersCommand : CommandBase
    {
        private readonly TravelsOverviewViewModel _viewModel;
        public ApplyFiltersCommand(TravelsOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.MinPrice) || e.PropertyName == nameof(_viewModel.MaxPrice))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return ValidatePriceRange(_viewModel.MinPrice, _viewModel.MaxPrice, out decimal? minPrice, out decimal? maxPrice)
                && ValidateDates(_viewModel.StartDate, _viewModel.EndDate)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            double minPrice = 0;
            double maxPrice = 10000000;

            if (!string.IsNullOrWhiteSpace(_viewModel.MinPrice))
            {
                minPrice = Convert.ToDouble(_viewModel.MinPrice);
            }

            if (!string.IsNullOrWhiteSpace(_viewModel.MaxPrice))
            {
                maxPrice = Convert.ToDouble(_viewModel.MaxPrice);
            }

            DateTime minDate = DateTime.Today;
            DateTime maxDate = DateTime.Today.AddDays(365);

            if (_viewModel.StartDate != null)
            {
                minDate = (DateTime)_viewModel.StartDate;
            }

            if (_viewModel.EndDate != null) 
            {
                maxDate = (DateTime)_viewModel.EndDate;
            }

            _viewModel.FilteredTravels = _viewModel.TravelService.Filter(new ObservableCollection<Model.TravelManagement.Travel>(_viewModel.Travels), minPrice, maxPrice, 
                minDate, maxDate);
        }

        private bool ValidatePriceRange(string minPriceText, string maxPriceText, out decimal? minPrice, out decimal? maxPrice)
        {
            minPrice = null;
            maxPrice = null;

            if (string.IsNullOrWhiteSpace(minPriceText) && string.IsNullOrWhiteSpace(maxPriceText))
            {
                _viewModel.ErrMsgText = "";
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }

            if (!string.IsNullOrWhiteSpace(minPriceText))
            {
                if (!decimal.TryParse(minPriceText, out decimal parsedMinPrice) || parsedMinPrice < 0)
                {
                    _viewModel.ErrMsgText = "Min price must be a positive number.";
                    _viewModel.ErrMsgVisibility = Visibility.Visible;
                    return false;
                }
                minPrice = parsedMinPrice;
            }

            if (!string.IsNullOrWhiteSpace(maxPriceText))
            {
                if (!decimal.TryParse(maxPriceText, out decimal parsedMaxPrice) || parsedMaxPrice < 0)
                {
                    _viewModel.ErrMsgText = "Max price must be a positive number.";
                    _viewModel.ErrMsgVisibility = Visibility.Visible;
                    return false;
                }
                maxPrice = parsedMaxPrice;
            }

            if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
            {
                _viewModel.ErrMsgText = "Min price can't be greater than max price.";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
                return false;
            }

            _viewModel.ErrMsgText = "";
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;

        }

        public bool ValidateDates(DateTime? startDate, DateTime? endDate)
        {
            // Check if both values are null or empty strings
            if ((!startDate.HasValue || startDate.Value == DateTime.MinValue) && (!endDate.HasValue || endDate.Value == DateTime.MinValue))
            {
                _viewModel.ErrMsgText = "";
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }

            // Check if one value is null or empty string and the other has a value
            if ((startDate.HasValue && startDate.Value != DateTime.MinValue && (!endDate.HasValue || endDate.Value == DateTime.MinValue))
                || ((!startDate.HasValue || startDate.Value == DateTime.MinValue) && endDate.HasValue && endDate.Value != DateTime.MinValue))
            {
                _viewModel.ErrMsgText = "";
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return true;
            }

            // Check if start date is not null or empty string and is today or a future date
            if (startDate.HasValue && startDate.Value != DateTime.MinValue && startDate.Value.Date < DateTime.Today)
            {
                _viewModel.ErrMsgText = "Dates have to be in the future.";
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return false;
            }

            // Check if both values are not null or empty string and start date is not greater than end date
            if (startDate.HasValue && startDate.Value != DateTime.MinValue && endDate.HasValue && endDate.Value != DateTime.MinValue
                && startDate.Value.Date > endDate.Value.Date)
            {
                _viewModel.ErrMsgText = "End date can't be greater then start date.";
                _viewModel.ErrMsgVisibility = Visibility.Hidden;
                return false;
            }

            _viewModel.ErrMsgText = "";
            _viewModel.ErrMsgVisibility = Visibility.Hidden;
            return true;
        }

    }
}
