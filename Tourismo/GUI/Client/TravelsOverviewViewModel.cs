using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;
using Tourismo.Resources.Variables;

namespace Tourismo.GUI.Client
{
    public class TravelsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private readonly List<Travel> _travels;
        private ObservableCollection<Travel> _filteredTravels;
        private string _searchText;
        private ITravelService _travelService;
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _lowerBoundaryStart;
        private DateTime _lowerBoundaryEnd;
        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        private List<string> _sortBy = VariableResources.TravelSortValues;

        #endregion

        #region Properties

        public List<Travel> Travels => _travels;

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

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                LowerBoundaryEnd = _startDate.AddDays(1);
                if (DateTime.Compare(EndDate, LowerBoundaryEnd) < 0)
                {
                    EndDate = LowerBoundaryEnd;
                }
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public MyMapCredentials MapApiKey => _mapApiKey;

        public DateTime LowerBoundaryStart => _lowerBoundaryStart;

        public DateTime LowerBoundaryEnd 
        {
            get { return _lowerBoundaryEnd; } 
            set 
            {
                _lowerBoundaryEnd = value;
                OnPropertyChanged(nameof(LowerBoundaryEnd));
            } 
        }

        #endregion

        
        public TravelsOverviewViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            _travels = _travelService.ReadAll().OrderBy(t => t.Name).ToList();
            _startDate = DateTime.Now;
            _endDate = DateTime.Now.AddDays(1);
            _lowerBoundaryStart = DateTime.Now;
            _lowerBoundaryEnd = _lowerBoundaryStart.AddDays(1);

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
