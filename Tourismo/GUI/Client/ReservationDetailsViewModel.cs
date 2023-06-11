using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Model.TravelManagement;
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
        #endregion

        #region Commands

        public ICommand PreviousAttractionCommand { get; private set; }
        public ICommand NextAttractionCommand { get; private set; }
        public ICommand CancelReservationCommand { get; private set; }

        #endregion

        public ReservationDetailsViewModel(IArrangementService arrangementService, ITravelService travelService)
        {
            _arrangementService = arrangementService;
            _arrangement = GlobalStore.ReadObject<Arrangement>("SelectedArrangament");

            _additionalAttractions = _arrangement.AdditionalAttractions.OrderBy(a => a.CreatedAt).ToList();
            _travel = travelService.ReadAllActive().FirstOrDefault(t => t.Id == _arrangement.Travel.Id);
            _arrangement.Travel = _travel;
            _allAttractions = _travel.DefaultAttractions
                .Concat(_additionalAttractions).ToList();
            _currentAttraction = _allAttractions[0];

            NextAttractionCommand = new RelayCommand(NextAttraction);
            PreviousAttractionCommand = new RelayCommand(PreviousAttraction);
            CancelReservationCommand = new RelayCommand(CancelReservation);

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
        }

        private void PreviousAttraction()
        {

            if (_attractionsIndex == 0)
                _attractionsIndex = _allAttractions.Count - 1;
            else _attractionsIndex--;
            CurrentAttraction = _allAttractions[_attractionsIndex];
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
    }
}
