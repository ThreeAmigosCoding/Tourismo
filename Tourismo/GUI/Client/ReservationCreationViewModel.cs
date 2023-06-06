using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Commands.Client;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Client
{
    public class ReservationCreationViewModel : NavigableViewModel
    {

        private Travel _travel;
        public Travel Travel
        {
            get => _travel;
            set
            {
                _travel = value;
                OnPropertyChanged(nameof(Travel));
            }
        }


        public ReservationCreationViewModel()
        {
            _travel = GlobalStore.ReadObject<Travel>("TravelForReservation");
        }
    }
}
