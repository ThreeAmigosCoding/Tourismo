using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Implementation.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Client
{
    class ReservationDetailsViewModel : NavigableViewModel
    {
        #region Attributes

        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        private Arrangement _arrangement;
        private List<TouristAttraction> _allAttractions;
        private List<TouristAttraction> _additionalAttractions;
        private int _attractionsIndex = 0;
        private TouristAttraction _currentAttraction;
        private IArrangementService _arrangementService;
        private ITravelService _travelService;
        private Travel _travel;
        private Visibility _cancelButtonVisibility;

        private List<AttractionLocation> _attractionLocations;
        private Microsoft.Maps.MapControl.WPF.Location _mapCenter;
        private double _mapZoomLevel;
        private AccommodationLocation _accommodationLocation;

        private List<AccommodationLocation> _restaurants;
        private IAccommodationService _accommodationService;

        #endregion

        #region Properties

        public MyMapCredentials MapApiKey => _mapApiKey;

        public Arrangement Arrangement
        {
            get => _arrangement;
            set
            {
                _arrangement = value;
                OnPropertyChanged(nameof(Arrangement));
            }
        }

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
                OnPropertyChanged(nameof(CurrentAttraction));
            }
        }

        public Visibility CancelVisibility
        {
            get { return _cancelButtonVisibility; }
            set
            {
                _cancelButtonVisibility = value;
                OnPropertyChanged(nameof(CancelVisibility));
            }
        }

        public IArrangementService ArrangementService { get => _arrangementService; }

        public ITravelService TravelService { get => _travelService; }

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

        public List<AccommodationLocation> Restaurants
        {
            get { return _restaurants; }
            set
            {
                _restaurants = value;
                OnPropertyChanged(nameof(Restaurants));
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

        public string RestaurantPin
        {
            get => "Pins/restaurant.png";
        }

        public IAccommodationService AccommodationService { get => _accommodationService; }

        #endregion

        #region Commands

        public ICommand PreviousAttractionCommand { get; private set; }
        public ICommand NextAttractionCommand { get; private set; }
        public ICommand CancelReservationCommand { get; private set; }
        public ICommand PushpinClickCommand { get; private set; }
        public ICommand AccommodationClickCommand { get; private set; }
        public ICommand RestaurantClickCommand { get; private set; }


        #endregion

        public ReservationDetailsViewModel(IArrangementService arrangementService, ITravelService travelService, 
            IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
            _arrangementService = arrangementService;
            _arrangement = GlobalStore.ReadObject<Arrangement>("SelectedArrangament");

            _additionalAttractions = _arrangement.AdditionalAttractions.OrderBy(a => a.CreatedAt).ToList();
            _travel = travelService.ReadAllActive().FirstOrDefault(t => t.Id == _arrangement.Travel.Id);
            _arrangement.Travel = _travel;
            _allAttractions = _travel.DefaultAttractions
                .Concat(_additionalAttractions).ToList();
            _currentAttraction = _allAttractions[0];

            InitializeMap();

            NextAttractionCommand = new RelayCommand(NextAttraction);
            PreviousAttractionCommand = new RelayCommand(PreviousAttraction);
            CancelReservationCommand = new RelayCommand(CancelReservation);

            PushpinClickCommand = new RelayCommand<object>(PushpinClick);
            AccommodationClickCommand = new RelayCommand(AccommodationClick);
            RestaurantClickCommand = new RelayCommand<object>(RestaurantClick);

            if (GlobalStore.ReadObject<string>("ReservationDetails") == "history")
                CancelVisibility = Visibility.Hidden;
            else CancelVisibility = Visibility.Visible;
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

        private void CancelReservation()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel this reservation: "
                + _arrangement.Travel.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _arrangement.ArrangementStatus = ArrangementStatus.Canceled;
                ArrangementService.Update(_arrangement);
                EventBus.FireEvent("ClientReservationsOverview");
            }
        }

        private void InitializeMap()
        {
            _attractionLocations = new List<AttractionLocation>(_allAttractions.Concat(AdditionalAttractions)
                .Select(al => new AttractionLocation(al)));
            MapZoomLevel = 7;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(44.0165, 21.0059);
            AccommodationLocation = new AccommodationLocation(Travel.Accommodation);

            List<Accommodation> allRestaurants = AccommodationService.ReadAll()
                .Where(a => a.Type == AccommodationType.Restaurant)
                .ToList();

            Restaurants = MapUtils.GetRestaurantsWithinRadius(allRestaurants,
                AccommodationLocation.Location.Latitude,
                AccommodationLocation.Location.Longitude,
                1.5).Select(a => new AccommodationLocation(a)).ToList();
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

        public void RestaurantClick(object? parametar)
        {
            Accommodation restaurant = (Accommodation)parametar;
            MapZoomLevel = 8;
            MapCenter = new Microsoft.Maps.MapControl.WPF.Location(
                restaurant.Location.Latitude,
                restaurant.Location.Longitude);
            string displayInfo = "Address: " + restaurant.Location.Address + "\n" +
                "Half board price: " + restaurant.Price + " rsd";
            MessageBox.Show(displayInfo, restaurant.Name);
        }

    }
}
