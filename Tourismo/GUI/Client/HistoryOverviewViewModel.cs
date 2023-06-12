using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Commands.Client;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Client
{
    public class HistoryOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private List<Arrangement> _history;
        private IArrangementService _arrangementService;

        private Arrangement _selectedArrangament; 

        #endregion

        #region Properties

        public List<Arrangement> History
        {
            get { return _history; }
            set
            {
                _history = value;
                OnPropertyChanged(nameof(History));
            }
        }

        public Arrangement SelectedArrangement
        {
            get { return _selectedArrangament; }
            set
            {
                _selectedArrangament = value;
                OnPropertyChanged(nameof(SelectedArrangement));
                GlobalStore.AddObject("SelectedArrangament", _selectedArrangament);
                SwitchToReservationDetails.Execute("history");
            }
        }

        public IArrangementService ArrangementService { get => _arrangementService; }

        #endregion

        #region Commands

        ICommand SwitchToReservationDetails { get; }

        #endregion

        public HistoryOverviewViewModel(IArrangementService arrangementService)
        {
            _arrangementService = arrangementService;
            _history = _arrangementService.GetUserHistory(GlobalStore.ReadObject<User>("LoggedUser").EmailAddress);
            SwitchToReservationDetails = new SwitchToReservationDetails();
        }

    }
}
