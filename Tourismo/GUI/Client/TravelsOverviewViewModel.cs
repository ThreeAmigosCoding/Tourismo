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

namespace Tourismo.GUI.Client
{
    public class TravelsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private readonly List<Travel> _travels;
        private ObservableCollection<Travel> _filteredTravels;
        private string _searchText;
        private ITravelService _travelService;
        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        #endregion

        #region Properties

        public List<Travel> Travels => _travels;
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

        public MyMapCredentials MapApiKey => _mapApiKey;

        #endregion

        
        public TravelsOverviewViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            _travels = _travelService.ReadAll().OrderBy(t => t.Name).ToList();
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
