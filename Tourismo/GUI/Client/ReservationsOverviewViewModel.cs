using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Service.Implementation.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Client
{
    public class ReservationsOverviewViewModel : NavigableViewModel
    {
        #region Attributes

        private List<Arrangement> _reservations;
        private IArrangementService _arrangementService;

        #endregion

        #region Properties

        public List<Arrangement> Reservations
        {
            get { return _reservations; }
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public IArrangementService ArrangementService { get => _arrangementService; }

        #endregion

        public ReservationsOverviewViewModel(IArrangementService arrangementService) {
            _arrangementService = arrangementService;
            _reservations = _arrangementService.GetUserReservations(GlobalStore.ReadObject<User>("LoggedUser").EmailAddress);
        }


    }
}
