using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Auth;
using Tourismo.Core.Commands.Navigation;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Ninject;
using Tourismo.Core.Utility;
using Tourismo.GUI.Client;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Navigation
{
    public class ClientHomeViewModel : NavigableViewModel
    {

        public string Name
        {
            get => GlobalStore.ReadObject<User>("LoggedUser").FirstName;
        }

        public ICommand? LogOutCommand { get; set; }
        public ICommand? ClientTravelsOverviewCommand { get; set; }
        public ICommand? ClientReservationsOverviewCommand { get; set; }
        public ICommand? ClientHistoryOverviewCommand { get; set; }
        public ICommand? ClientHelpCommand { get; set; }


        public ClientHomeViewModel() {
            ClientTravelsOverviewCommand = new ClientTravelsOverviewCommand();
            ClientReservationsOverviewCommand = new ClientReservationsOverviewCommand();
            ClientHistoryOverviewCommand = new ClientHistoryOverviewCommand();
            ClientHelpCommand = new ClientHelpCommand();
            LogOutCommand = new LogOutCommand();
            SwitchCurrentViewModel(ServiceLocator.Get<TravelsOverviewViewModel>());
            RegisterHandler();
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("ClientTravelsOverview", () =>
            {
                TravelsOverviewViewModel TravelsOverviewViewModel = ServiceLocator.Get<TravelsOverviewViewModel>();
                SwitchCurrentViewModel(TravelsOverviewViewModel);
            });

            EventBus.RegisterHandler("ClientReservationsOverview", () =>
            {
                ReservationsOverviewViewModel ReservationsOverviewViewModel = ServiceLocator.Get<ReservationsOverviewViewModel>();
                SwitchCurrentViewModel(ReservationsOverviewViewModel);
            });
            EventBus.RegisterHandler("ClientHistoryOverview", () =>
            {
                HistoryOverviewViewModel HistoryOverviewViewModel = ServiceLocator.Get<HistoryOverviewViewModel>();
                SwitchCurrentViewModel(HistoryOverviewViewModel);
            });
            EventBus.RegisterHandler("OpenReservationCreation", (SelectedTravel) =>
            {
                GlobalStore.AddObject("TravelForReservation", SelectedTravel);
                ReservationCreationViewModel ReservationCreationViewModel = ServiceLocator.Get<ReservationCreationViewModel>();
                SwitchCurrentViewModel(ReservationCreationViewModel);
            });
            EventBus.RegisterHandler("ReservationDetails", () =>
            {
                ReservationDetailsViewModel ReservationDetailsViewModel = ServiceLocator.Get<ReservationDetailsViewModel>();
                SwitchCurrentViewModel(ReservationDetailsViewModel);
            });
            EventBus.RegisterHandler("ClientHelp", () =>
            {
                ClientHelpViewModel ClientHelpViewModel = ServiceLocator.Get<ClientHelpViewModel>();
                SwitchCurrentViewModel(ClientHelpViewModel);
            });
        }

    }
}
