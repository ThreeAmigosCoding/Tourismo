using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    class TravelCRUDViewModel : NavigableViewModel
    {
        #region Attributes

        private Travel _travel;
        private string _mode;
        private ITouristAttractionService _attractionService;
        private IAccommodationService _accommodationService;
        private ITravelService _travelService;
        private List<TouristAttraction> _allAttractions;
        private ObservableCollection<Accommodation> _accommodations;
        private Accommodation _selectedAccommodation;
        private ObservableCollection<TouristAttraction> _filteredAttractions;
        private ObservableCollection<TouristAttraction> _defaultAttractions = new ObservableCollection<TouristAttraction>();
        private ObservableCollection<TouristAttraction> _additionalAttractions = new ObservableCollection<TouristAttraction>();
        private string _searchAttractionsText;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime _lowerBoundaryStart;
        private DateTime _lowerBoundaryEnd;
        private ObservableCollection<DateRange> _periods;
        private int _periodsLength;
        private DateRange _selectedPeriod;
        private string _errMsgText;
        private Visibility _errMsgVisibility;
        private Visibility _deleteButtonVisibility;

        #endregion

        #region Properties

        public Travel Travel
        {
            get { return _travel; }
            set
            {
                _travel = value;
                OnPropertyChanged(nameof(Travel));
            }
        }
        public string Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }
        public ITouristAttractionService AttractionService { get => _attractionService; }
        public IAccommodationService AccommodationService { get => _accommodationService; }
        public ITravelService TravelService { get => _travelService; }
        public List<TouristAttraction> AllAttractions
        {
            get { return _allAttractions; }
            set
            {
                _allAttractions = value;
                OnPropertyChanged(nameof(AllAttractions));
            }
        }
        public IEnumerable<Accommodation> Accommodations
        {
            get { return _accommodations; }
            set
            {
                _accommodations = (ObservableCollection<Accommodation>)value;
                OnPropertyChanged(nameof(Accommodations));
            }
        }
        public Accommodation SelectedAccommodation
        {
            get { return _selectedAccommodation; }
            set
            {
                _selectedAccommodation = value;
                OnPropertyChanged(nameof(SelectedAccommodation));
            }
        }
        public IEnumerable<TouristAttraction> FilteredAttractions
        {
            get { return _filteredAttractions; }
            set
            {
                _filteredAttractions = (ObservableCollection<TouristAttraction>)value;
                OnPropertyChanged(nameof(FilteredAttractions));
            }
        }
        public IEnumerable<TouristAttraction> DefaultAttractions
        {
            get { return _defaultAttractions; }
            set
            {
                _defaultAttractions = (ObservableCollection<TouristAttraction>)value;
                OnPropertyChanged(nameof(DefaultAttractions));
            }
        }
        public IEnumerable<TouristAttraction> AdditionalAttractions
        {
            get { return _additionalAttractions; }
            set
            {
                _additionalAttractions = (ObservableCollection<TouristAttraction>)value;
                OnPropertyChanged(nameof(AdditionalAttractions));
            }
        }
        public string SearchAttractionsText
        {
            get { return _searchAttractionsText; }
            set
            {
                _searchAttractionsText = value;
                FilterItems();
                OnPropertyChanged(nameof(SearchAttractionsText));
            }
        }
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
        public ObservableCollection<DateRange> Periods
        {
            get { return _periods; }
            set
            {
                _periods = value;
                OnPropertyChanged(nameof(Periods));
            }
        }
        public int PeriodsLength
        {
            get { return _periodsLength; }
            set
            {
                _periodsLength = value;
                OnPropertyChanged(nameof(PeriodsLength));
            }
        }
        public DateRange SelectedPeriod
        {
            get { return _selectedPeriod; }
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged(nameof(SelectedPeriod));
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
        public Visibility DeleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged(nameof(DeleteButtonVisibility));
            }
        }

        public AttractionDragDropViewModel AllAttractionsDragDropViewModel { get; } = new AttractionDragDropViewModel();
        public AttractionDragDropViewModel DefaultAttractionsDragDropViewModel { get; } = new AttractionDragDropViewModel();
        public AttractionDragDropViewModel AdditionalAttractionsDragDropViewModel { get; } = new AttractionDragDropViewModel();

        #endregion

        #region Commands

        public ICommand? ChooseTravelImageCommand { get; }
        public ICommand? AddPeriodCommand { get; }
        public ICommand? RemovePeriodCommand { get; }
        public ICommand? SaveTravelCommand { get; }

        #endregion

        public TravelCRUDViewModel(ITouristAttractionService attractionService, IAccommodationService accommodationService, ITravelService travelService) {
            _attractionService = attractionService;
            _accommodationService = accommodationService;
            _travelService = travelService;
            _allAttractions = _attractionService.ReadAll().OrderBy(a => a.Name).ToList();
            _accommodations = new ObservableCollection<Accommodation>(_accommodationService.ReadAllNonRestaurants().OrderBy(a => a.Name));

            _startDate = null;
            _endDate = null;
            _lowerBoundaryStart = DateTime.Now;
            _lowerBoundaryEnd = _lowerBoundaryStart.AddDays(1);

            _mode = GlobalStore.ReadObject<string>("TravelCRUDMode");
            if (_mode != null && _mode == "update")
            {
                _deleteButtonVisibility = Visibility.Visible;
                _travel = GlobalStore.ReadObject<Travel>("SelectedTravel");
                _selectedAccommodation = _travel.Accommodation;
                foreach (TouristAttraction defaultAttraction in _travel.DefaultAttractions)
                {
                    DefaultAttractionsDragDropViewModel.AddAttraction(defaultAttraction);
                }
                foreach (TouristAttraction additionalAttraction in _travel.AdditionalAttractions)
                {
                    AdditionalAttractionsDragDropViewModel.AddAttraction(additionalAttraction);
                }
                _periods = new ObservableCollection<DateRange>(_travel.Periods.OrderBy(p => p.StartDate));
                PeriodsLength = _periods.Count;
            }
            else
            {
                _deleteButtonVisibility = Visibility.Hidden;
                _travel = new Travel();
                _periods = new ObservableCollection<DateRange>();
                PeriodsLength = _periods.Count;
            }


            foreach (TouristAttraction attraction in _allAttractions)
            {
                if (!DefaultAttractionsDragDropViewModel.Attractions.Any(a => a.Id == attraction.Id) && !AdditionalAttractionsDragDropViewModel.Attractions.Any(a => a.Id == attraction.Id))
                    AllAttractionsDragDropViewModel.AddAttraction(attraction);
            }
                
            ChooseTravelImageCommand = new ChooseTravelImageCommand(this);
            AddPeriodCommand = new AddPeriodCommand(this);
            RemovePeriodCommand = new RemovePeriodCommand(this);
            SaveTravelCommand = new SaveTravelCommand(this);

            FilterItems();
        }

        private void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchAttractionsText))
            {
                AllAttractionsDragDropViewModel.Attractions = new ObservableCollection<TouristAttraction>(AllAttractionsDragDropViewModel.UnfilteredAttractions);
            }
            else
            {
                var filteredItems = AllAttractionsDragDropViewModel.UnfilteredAttractions.Where(a =>
                 a.Name.Contains(SearchAttractionsText, StringComparison.OrdinalIgnoreCase));
                AllAttractionsDragDropViewModel.Attractions = new ObservableCollection<TouristAttraction>(filteredItems);
            }
        }
    }
}
