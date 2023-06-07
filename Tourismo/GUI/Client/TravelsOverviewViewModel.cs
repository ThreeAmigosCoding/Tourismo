using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tourismo.Core.Commands.Client;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Ninject;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;
using Tourismo.Resources.Variables;

namespace Tourismo.GUI.Client
{
    public class TravelsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private List<Travel> _travels;
        private ObservableCollection<Travel> _filteredTravels;
        private string _searchText;
        private ITravelService _travelService;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime _lowerBoundaryStart;
        private DateTime _lowerBoundaryEnd;
        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        private List<string> _sortBy = VariableResources.TravelSortValues;
        private string _sortCriteria = "Date (soonest first)";
        private string _minPrice;
        private string _maxPrice;
        private Visibility _errMsgVisibility;
        private string _errMsgText;
        private Travel _selectedTravel;

        #endregion

        #region Properties

        public List<Travel> Travels
        {
            get { return _travels; }
            set
            {
                _travels = value;
                OnPropertyChanged(nameof(Travels));
            }
        }

        public List<string> SortBy => _sortBy;

        public ObservableCollection<Travel> FilteredTravels
        {
            get { return _filteredTravels; }
            set
            {
                _filteredTravels = value;
                OnPropertyChanged(nameof(FilteredTravels));
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                FilterItems();
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public ITravelService TravelService { get => _travelService; }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                if (StartDate != null) LowerBoundaryEnd = _startDate.Value.AddDays(1);
                if (EndDate != null && DateTime.Compare((DateTime)EndDate, LowerBoundaryEnd) < 0)
                {
                    EndDate = LowerBoundaryEnd;
                }
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public MyMapCredentials MapApiKey => _mapApiKey;

        public DateTime LowerBoundaryStart
        {
            get { return _lowerBoundaryStart; }
            set
            {
                _lowerBoundaryStart = value;
                OnPropertyChanged(nameof(LowerBoundaryStart));
            }
        }

        public DateTime LowerBoundaryEnd 
        {
            get { return _lowerBoundaryEnd; } 
            set 
            {
                _lowerBoundaryEnd = value;
                OnPropertyChanged(nameof(LowerBoundaryEnd));
            } 
        }

        public string SortCriteria
        {
            get => _sortCriteria;
            set
            {
                _sortCriteria = value;
                FilteredTravels = _travelService.SortByCriteria(FilteredTravels, SortCriteria);
                Travels = _travelService.SortByCriteria(new ObservableCollection<Travel>(Travels), SortCriteria).ToList();
                OnPropertyChanged(nameof(SortCriteria));
            }
        }

        public string MinPrice
        {
            get => _minPrice;
            set
            {
                _minPrice = value;
                OnPropertyChanged(nameof(MinPrice));
            }
        }

        public string MaxPrice
        {
            get => _maxPrice;
            set
            {
                _maxPrice = value;
                OnPropertyChanged(nameof(MaxPrice));
            }
        }

        public string ErrMsgText
        {
            get => _errMsgText;
            set
            {
                _errMsgText = value;
                OnPropertyChanged(nameof(ErrMsgText));
            }
        }

        public Visibility ErrMsgVisibility
        {
            get => _errMsgVisibility;
            set
            {
                _errMsgVisibility = value;
                OnPropertyChanged(nameof(ErrMsgVisibility));
            }
        }

        public Travel SelectedTravel
        {
            get => _selectedTravel;
            set
            {
                _selectedTravel = value;
                OpenReservationCreationCommand.Execute(this);
                OnPropertyChanged(nameof(SelectedTravel));
            }
        }

        #endregion

        #region Commands

        public ICommand ApplyFiltersCommand { get; }
        public ICommand ResetFiltersCommand { get; }
        public ICommand OpenReservationCreationCommand { get; }

        #endregion 


        public TravelsOverviewViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            _travels = _travelService.ReadAll().OrderBy(t => t.Periods.Min(p => p.StartDate)).ToList();
            _startDate = null;
            _endDate = null;
            _lowerBoundaryStart = DateTime.Now;
            _lowerBoundaryEnd = _lowerBoundaryStart.AddDays(1);

            ResetFiltersCommand = new ResetFiltersCommand(this);
            ApplyFiltersCommand = new ApplyFiltersCommand(this);
            OpenReservationCreationCommand = new OpenReservationCreationCommand(this);

            FilterItems();
        }

        private void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredTravels = new ObservableCollection<Travel>(Travels);
            }
            else
            {
                var filteredItems = Travels.Where(t =>
                 t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                 t.ShortDescription.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                 .ToList();

                FilteredTravels = new ObservableCollection<Travel>(filteredItems);
            }
        }

        
    }
}
