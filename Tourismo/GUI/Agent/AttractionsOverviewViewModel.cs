using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Implementation.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    class AttractionsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private List<TouristAttraction> _attractions;
        private ObservableCollection<TouristAttraction> _fillteredAttractions;
        private ITouristAttractionService _attractionService;
        private string _searchText;

        private TouristAttraction _selectedAttraction;

        #endregion

        #region Properties

        public List<TouristAttraction> Attractions
        {
            get { return _attractions; }
            set
            {
                _attractions = value;
                OnPropertyChanged(nameof(Attractions));
            }
        }

        public ObservableCollection<TouristAttraction> FilteredAttractions
        {
            get { return _fillteredAttractions; }
            set
            {
                _fillteredAttractions = value;
                OnPropertyChanged(nameof(FilteredAttractions));
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

        public TouristAttraction SelectedAttraction
        {
            get { return _selectedAttraction; }
            set
            {
                _selectedAttraction = value;
                OnPropertyChanged(nameof(SelectedAttraction));
                GlobalStore.AddObject("SelectedAttraction", _selectedAttraction);
                SwitchToAttractionCRUD.Execute("update");
            }
        }

        public ITouristAttractionService AttractionService { get => _attractionService; }

        #endregion

        #region Commands

        public ICommand SwitchToAttractionCRUD { get; }
        public ICommand DeleteAttractionCommand { get; }

        #endregion

        public AttractionsOverviewViewModel(ITouristAttractionService attractionService)
        {
            _attractionService = attractionService;
            _attractions = _attractionService.ReadAllActive().ToList();
            FilterItems();

            SwitchToAttractionCRUD = new SwitchToAttractionCRUD();
            DeleteAttractionCommand = new DeleteAttractionCommand(this);
        }

        public void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredAttractions = new ObservableCollection<TouristAttraction>(Attractions);
            }
            else
            {
                var filteredItems = Attractions.Where(t =>
                 t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                 .ToList();

                FilteredAttractions = new ObservableCollection<TouristAttraction>(filteredItems);
            }
        }

    }
}
