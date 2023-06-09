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

namespace Tourismo.GUI.Navigation
{
    public class AgentHomeViewModel : NavigableViewModel
    {
        public string Name
        {
            get => GlobalStore.ReadObject<User>("LoggedUser").FirstName;
        }

        public ICommand? LogOutCommand { get; set; }

        public ICommand? AccommodationOverviewCommand { get; set; }

        public ICommand? ReportsOverviewCommand { get; set; }

        public AgentHomeViewModel()
        {
            LogOutCommand = new LogOutCommand();
            AccommodationOverviewCommand = new AgentAccommodationOverviewCommand();
            ReportsOverviewCommand = new AgentReportsOverviewCommand();
            SwitchCurrentViewModel(ServiceLocator.Get<ReportsOverviewViewModel>());
            RegisterHandler();
        }

        private void RegisterHandler()
        {
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
        }
    }
}
