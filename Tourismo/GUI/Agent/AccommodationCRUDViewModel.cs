using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Commands;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Commands.Navigation;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Agent
{
    public class AccommodationCRUDViewModel : NavigableViewModel
    {
        #region Attributes
        private string _mode;
        private MyMapCredentials _credentials = new MyMapCredentials();

        private Visibility _deleteButtonVisibility;

        private Accommodation _accommodation;

        private string _errMsgText;
        private Visibility _errMsgVisibility;

        private IAccommodationService _accommodationService;
        private Location _selectedLocation;

        #endregion

        #region Properties
        public string Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }

        public MyMapCredentials MapCredentials { get => _credentials; }

        public Visibility DeleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged(nameof(DeleteButtonVisibility));
            }
        }

        public Accommodation Accommodation
        {
            get { return _accommodation; }
            set
            {
                _accommodation = value;
                OnPropertyChanged(nameof(Accommodation));
            }
        }

        public List<AccommodationType> AccommodationTypes
        {
            get => Enum.GetValues(typeof(AccommodationType)).Cast<AccommodationType>().ToList();
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

        public IAccommodationService AccommodationService
        {
            get { return _accommodationService; }
            set
            {
                _accommodationService = value;
                OnPropertyChanged(nameof(_accommodationService));
            }
        }

        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                Accommodation.Location.Longitude = _selectedLocation.Longitude;
                Accommodation.Location.Latitude = _selectedLocation.Latitude;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        #endregion

        #region Commands
        public ICommand? SaveAccommodationCommand { get; }
        
        public ICommand? ChooseAccommodationImageCommand { get; }

        public ICommand? DeleteAccommodationCommand { get; }

        public ICommand? ViewAccommodationOnMapCommand { get; }
        
        public ICommand? AgentAccommodationOverviewCommand { get; }

        #endregion

        public AccommodationCRUDViewModel(IAccommodationService accommodationService) 
        {
            _accommodationService = accommodationService;
            _mode = GlobalStore.ReadObject<string>("AccommodationCRUDMode");
 
            if (_mode != null && _mode == "update")
            {
                _deleteButtonVisibility = Visibility.Visible;
                _accommodation = GlobalStore.ReadObject<Accommodation>("SelectedAccommodation");
                
                _selectedLocation = new Location(Accommodation.Location.Latitude, Accommodation.Location.Longitude);
                
            }
            else
            {
                _selectedLocation = new Location(44.0165, 21.0059);
                _deleteButtonVisibility = Visibility.Hidden;
                _accommodation = new Accommodation();
                _accommodation.Location = new Core.Model.Helper.Location();
            }

            SaveAccommodationCommand = new SaveAccommodationCommand(this);
            ChooseAccommodationImageCommand = new ChooseAccommodationImageCommand(this);
            DeleteAccommodationCommand = new DeleteAccommodationFromDetailsCommand(this);

            ViewAccommodationOnMapCommand = new ViewAccommodationOnMapCommand(this);

            AgentAccommodationOverviewCommand = new AgentAccommodationOverviewCommand();

        }
    }
}
