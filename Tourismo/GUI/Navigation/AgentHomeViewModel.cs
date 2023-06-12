using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Auth;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;
using Tourismo.Core.Ninject;
using Tourismo.Core.Commands.Navigation;
using Tourismo.GUI.Client;

namespace Tourismo.GUI.Navigation
{
    public class AgentHomeViewModel : NavigableViewModel
    {
        public string Name
        {
            get => GlobalStore.ReadObject<User>("LoggedUser").FirstName;
        }

        public ICommand? LogOutCommand { get; set; }

        public ICommand? TravelsOverviewCommand { get; set; }
        public ICommand? AccommodationOverviewCommand { get; set; }

        public ICommand? ReportsOverviewCommand { get; set; }

        public ICommand? AttractionsOverviewCommand { get; set; }

        public ICommand? AgentHelpCommand { get; set; }

        public AgentHomeViewModel()
        {
            LogOutCommand = new LogOutCommand();
            AccommodationOverviewCommand = new AgentAccommodationOverviewCommand();

            TravelsOverviewCommand = new AgentTravelsOverviewCommand();
            AttractionsOverviewCommand = new AgentAttractionOverviewCommand();
            SwitchCurrentViewModel(ServiceLocator.Get<TravelsOverviewViewModel>());

            ReportsOverviewCommand = new AgentReportsOverviewCommand();
            AttractionsOverviewCommand = new AgentAttractionOverviewCommand();
            AgentHelpCommand = new AgentHelpCommand();
            
            RegisterHandler();
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("AgentTravelsOverview", () =>
            {
                TravelsOverviewViewModel TravelsOverviewViewModel = ServiceLocator.Get<TravelsOverviewViewModel>();
                SwitchCurrentViewModel(TravelsOverviewViewModel);
            });

            EventBus.RegisterHandler("SwitchToTravelCRUD", () =>
            {
                TravelCRUDViewModel TravelCRUDViewModel = ServiceLocator.Get<TravelCRUDViewModel>();
                SwitchCurrentViewModel(TravelCRUDViewModel);
            });

            EventBus.RegisterHandler("AgentAccommodationOverview", () => 
            {
                AccommodationOverviewViewModel AccommodationOverviewViewModel = ServiceLocator.Get<AccommodationOverviewViewModel>();
                SwitchCurrentViewModel(AccommodationOverviewViewModel);
            });

            EventBus.RegisterHandler("SwitchToAccommodationCRUD", () =>
            {
                AccommodationCRUDViewModel AccommodationCRUDViewModel = ServiceLocator.Get<AccommodationCRUDViewModel>();
                SwitchCurrentViewModel(AccommodationCRUDViewModel);
            });


            EventBus.RegisterHandler("SwitchToAgentReportsOverview", () =>
            {
                ReportsOverviewViewModel ReportsOverviewViewModel = ServiceLocator.Get<ReportsOverviewViewModel>();
                SwitchCurrentViewModel(ReportsOverviewViewModel);
            });

            EventBus.RegisterHandler("SwitchToArrangementsForTravel", () =>
            {
                ArrangementsForTravelViewModel ArrangementsForTravelViewModel = ServiceLocator.Get<ArrangementsForTravelViewModel>();
                SwitchCurrentViewModel(ArrangementsForTravelViewModel);
            });
            
            EventBus.RegisterHandler("AgentAttractionOverview", () =>
            {
                AttractionsOverviewViewModel AttractionsOverviewViewModel = ServiceLocator.Get<AttractionsOverviewViewModel>();
                SwitchCurrentViewModel(AttractionsOverviewViewModel);
            });

            EventBus.RegisterHandler("SwitchToAttractionCRUD", () =>
            {
                AttractionCRUDViewModel AttractionCRUDViewModel = ServiceLocator.Get<AttractionCRUDViewModel>();
                SwitchCurrentViewModel(AttractionCRUDViewModel);
            });

            EventBus.RegisterHandler("AgentHelp", () =>
            {
                AgentHelpViewModel AgentHelpViewModel = ServiceLocator.Get<AgentHelpViewModel>();
                SwitchCurrentViewModel(AgentHelpViewModel);
            });
        }
    }
}
