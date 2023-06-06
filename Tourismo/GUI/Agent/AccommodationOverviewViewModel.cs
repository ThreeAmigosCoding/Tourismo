using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    public class AccommodationOverviewViewModel : NavigableViewModel
    {
        #region Attributes
        private List<Accommodation> _accommodations;
        private ObservableCollection<Accommodation> _filteredAccomodations;
        private IAccommodationService _accommodationService;
        private string _searchText;
        #endregion

        #region Properties
        public List<Accommodation> Accommodations 
        { 
            get { return _accommodations;}
            set
            { 
                _accommodations = value; 
                OnPropertyChanged(nameof(Accommodations));
            }
        }

        public ObservableCollection<Accommodation> FilteredAccomodations
        {
            get { return _filteredAccomodations; }
            set
            {
                _filteredAccomodations = value;
                OnPropertyChanged(nameof(FilteredAccomodations));
            }
        }

        public IAccommodationService AccommodationService { get => _accommodationService; }

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
        #endregion


        public AccommodationOverviewViewModel(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
            _accommodations = _accommodationService.ReadAllActive().ToList();
            FilterItems();
        }

        private void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredAccomodations = new ObservableCollection<Accommodation>(Accommodations);
            }
            else
            {
                var filteredItems = Accommodations.Where(t =>
                 t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                 .ToList();

                FilteredAccomodations = new ObservableCollection<Accommodation>(filteredItems);
            }
        }
    }
}
