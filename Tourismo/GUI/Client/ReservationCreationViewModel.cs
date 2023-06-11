using Microsoft.Maps.MapControl.WPF;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Commands.Client;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Service.Implementation.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Client
{
    public class ReservationCreationViewModel : NavigableViewModel
    {
        #region Attributes

        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        private Travel _travel;
        private List<TouristAttraction> _allAttractions;
        private List<TouristAttraction> _additionalAttractions;
        private int _attractionsIndex = 0;
        private TouristAttraction _currentAttraction;
        private List<AddedAttraction> _addedAttractions;
        private List<DateRange> _availablePeriods;
        private DateRange _selectedPeriod;
        private double _totalPrice;
        private string _additionalAttractionsSummary = "None";
        private IArrangementService _arrangementService;

        private List<AttractionLocation> _attractionLocations;
        private Microsoft.Maps.MapControl.WPF.Location _mapCenter;
        private double _mapZoomLevel;
        private AccommodationLocation _accommodationLocation;

        #endregion

        #region Properties

        public MyMapCredentials MapApiKey => _mapApiKey;
        public Travel Travel
        {
            get => _travel;
            set
            {
                _travel = value;
                OnPropertyChanged(nameof(Travel));
            }
        }
        public List<TouristAttraction> AllAttractions
        {
            get { return _allAttractions; }
            set
            {
                _allAttractions = value;
                OnPropertyChanged(nameof(AllAttractions));
            }
        }
        public List<TouristAttraction> AdditionalAttractions
        {
            get { return _additionalAttractions; }
            set
            {
                _additionalAttractions = value;
                OnPropertyChanged(nameof(AdditionalAttractions));
            }
        }

        public TouristAttraction CurrentAttraction
        {
            get => _currentAttraction;
            set
            {
                _currentAttraction = value;
                MapZoomLevel = 4;
                OnPropertyChanged(nameof(CurrentAttraction));
            }
        }

        public List<AddedAttraction> AddedAttractions
        {
            get => _addedAttractions;
            set
            {
                _addedAttractions = value;               
                OnPropertyChanged(nameof(AddedAttractions));
            }
        }

        public List<DateRange> AvailablePeriods
        {
            get => _availablePeriods;
            set
            {
                _availablePeriods = value;
                OnPropertyChanged(nameof(AvailablePeriods));
            }
        }

        public DateRange SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged(nameof(SelectedPeriod));
            }
        }

        public double TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public string AdditionalAttractionsSummary
        {
            get => _additionalAttractionsSummary;
            set
            {
                _additionalAttractionsSummary = value;
                OnPropertyChanged(nameof(AdditionalAttractionsSummary));
            }
        }

        public IArrangementService ArrangementService { get => _arrangementService; }

        public List<AttractionLocation> AttractionLocations
        {
            get => _attractionLocations;
            set
            {
                _attractionLocations = value;
                OnPropertyChanged(nameof(AttractionLocations));
            }
        }

        public double MapZoomLevel
        {
            get => _mapZoomLevel;
            set
            {
                _mapZoomLevel = value;
                OnPropertyChanged(nameof(MapZoomLevel));
            }
        }

        public Microsoft.Maps.MapControl.WPF.Location MapCenter
        {
            get => _mapCenter;
            set
            {
                _mapCenter = value;
                OnPropertyChanged(nameof(MapCenter));
            }
        }

        public AccommodationLocation AccommodationLocation
        {
            get { return _accommodationLocation; }
            set 
            {
                _accommodationLocation = value;
                OnPropertyChanged(nameof(AccommodationLocation));
            }
        }

        public string AccommodationPin
        {
            get => "Pins/accommodation.png";
        }

        public string AttractionPin
        {
            get => "Pins/attraction.png";
        }

        #endregion

        #region Commands

        public ICommand PreviousAttractionCommand { get; private set; }
        public ICommand NextAttractionCommand { get; private set; }
        public ICommand UpdateTotalPriceCommand { get; private set; }
        public ICommand MakeAReservationCommand { get; private set; }
        public ICommand PushpinClickCommand { get; private set; }
        public ICommand AccommodationClickCommand { get; private set; }

        #endregion

        public ReservationCreationViewModel(IArrangementService arrangementService)
        {
            _arrangementService = arrangementService;
            _travel = GlobalStore.ReadObject<Travel>("TravelForReservation");
            _additionalAttractions = _travel.AdditionalAttractions.OrderBy(a => a.CreatedAt).ToList();
            _allAttractions = _travel.DefaultAttractions.OrderBy(a => a.CreatedAt).Concat(_additionalAttractions).ToList();
            _currentAttraction = _allAttractions[0];
            _availablePeriods = _travel.Periods.Where(p => p.StartDate > DateTime.Today).OrderBy(p => p.StartDate).ToList();
            if (_availablePeriods.Count > 0)
                _selectedPeriod = _availablePeriods[0];

            _addedAttractions = new List<AddedAttraction>();
            foreach (TouristAttraction additionalAttraction in _additionalAttractions)      
                _addedAttractions.Add(new AddedAttraction(additionalAttraction));

            _totalPrice = _travel.MinimalPrice;

            InitializeMap();

            NextAttractionCommand = new RelayCommand(NextAttraction);
            PreviousAttractionCommand = new RelayCommand(PreviousAttraction);
            UpdateTotalPriceCommand = new RelayCommand(UpdateTotalPrice);
            MakeAReservationCommand = new RelayCommand(MakeAReservation);
            PushpinClickCommand = new RelayCommand<object>(PushpinClick);
            AccommodationClickCommand = new RelayCommand(AccommodationClick);
        }
        
        private void NextAttraction()
        {
            if (_attractionsIndex == _allAttractions.Count - 1)
                _attractionsIndex = 0;
            else _attractionsIndex++;
            CurrentAttraction = _allAttractions[_attractionsIndex];
            MapZoomLevel = 8;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(
                CurrentAttraction.Location.Latitude, 
                CurrentAttraction.Location.Longitude);
        }

        private void PreviousAttraction()
        {
            
            if (_attractionsIndex == 0)
                _attractionsIndex = _allAttractions.Count - 1;
            else _attractionsIndex--;
            CurrentAttraction = _allAttractions[_attractionsIndex];
            MapZoomLevel = 8;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(
                CurrentAttraction.Location.Latitude, 
                CurrentAttraction.Location.Longitude);
        }

        private void UpdateTotalPrice()
        {
            TotalPrice = Travel.MinimalPrice;
            AdditionalAttractionsSummary = "";
            foreach (AddedAttraction addedAttraction in AddedAttractions)
            {
                if (addedAttraction.IsSelected)
                {
                    TotalPrice += addedAttraction.Attraction.Price;
                    AdditionalAttractionsSummary += addedAttraction.Attraction.Name + ", ";
                }
            }
            if (AdditionalAttractionsSummary != "")
                AdditionalAttractionsSummary = AdditionalAttractionsSummary.Substring(0, AdditionalAttractionsSummary.Length - 2);
            else
                AdditionalAttractionsSummary = "None";
        }

        private void MakeAReservation()
        {
            string summary = "• " + Travel.Name + "\n• Additional attractions: " + AdditionalAttractionsSummary + "\n• " + SelectedPeriod + "\n• Price: " + TotalPrice + "rsd";
            MessageBoxResult result = MessageBox.Show(summary, "Make a reservation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                List<TouristAttraction> selectedAttractions = new List<TouristAttraction>();
                foreach (AddedAttraction addedAttraction in AddedAttractions)
                {
                    if (addedAttraction.IsSelected)
                        selectedAttractions.Add(addedAttraction.Attraction);
                }
                Arrangement arrangement = new Arrangement
                {
                    Traveler = GlobalStore.ReadObject<User>("LoggedUser"),
                    Travel = Travel,
                    AdditionalAttractions = selectedAttractions,
                    Period = SelectedPeriod,
                    Price = TotalPrice,
                    ArrangementStatus = ArrangementStatus.Reserved
                };
                _arrangementService.Create(arrangement);
                MessageBox.Show("Reservation Confirmed! Your travel plans are set, get ready for an amazing journey!");
                EventBus.FireEvent("ClientTravelsOverview");
            }
        }

        private void InitializeMap()
        {
            _attractionLocations = new List<AttractionLocation>(_allAttractions.Concat(AdditionalAttractions)
                .Select(al => new AttractionLocation(al)));
            MapZoomLevel = 7;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(44.0165, 21.0059);
            AccommodationLocation = new AccommodationLocation(Travel.Accommodation);
        }

        public void PushpinClick(object? parameter)
        {
            Guid id = (Guid)parameter;
            for (int i = 0; i < _allAttractions.Count; i++)
            {
                if (id == _allAttractions[i].Id)
                {
                    CurrentAttraction = _allAttractions[i];
                    _attractionsIndex = i;
                    MapZoomLevel = 8;
                    MapCenter = new Microsoft.Maps.MapControl.WPF.Location(
                        CurrentAttraction.Location.Latitude,
                        CurrentAttraction.Location.Longitude);
                    break;
                }
            }
        }

        public void AccommodationClick()
        {
            MapZoomLevel = 8;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(
                        Travel.Accommodation.Location.Latitude,
                        Travel.Accommodation.Location.Longitude);
        }
    }

    public class AddedAttraction : BaseObservableEntity
    {
        private TouristAttraction _attraction;
        private bool _isSelected;
        public TouristAttraction Attraction
        {
            get => _attraction;
            set
            {
                _attraction = value;
                OnPropertyChanged(nameof(Attraction));
            }
        }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public AddedAttraction(TouristAttraction attraction) {
            _attraction = attraction;
            _isSelected = false;
        }

    }

    public class AttractionLocation
    {
        public TouristAttraction TouristAttraction { get; set; }
        public string Name { get; set; }
        public Microsoft.Maps.MapControl.WPF.Location Location { get; set; }

        public AttractionLocation(TouristAttraction attraction) 
        {
            TouristAttraction = attraction;
            Name = attraction.Name;
            Location = new Microsoft.Maps.MapControl.WPF.Location(attraction.Location.Latitude, attraction.Location.Longitude);
        }

    }

    public class AccommodationLocation
    {
        public Accommodation Accommodation { get; set; }
        public string Name { get; set; }
        public Microsoft.Maps.MapControl.WPF.Location Location { get; set; }

        public AccommodationLocation(Accommodation accommodation)
        {
            Accommodation = accommodation;
            Name = accommodation.Name;
            Location = new Microsoft.Maps.MapControl.WPF.Location(accommodation.Location.Latitude, accommodation.Location.Longitude);
        }
    }
}
