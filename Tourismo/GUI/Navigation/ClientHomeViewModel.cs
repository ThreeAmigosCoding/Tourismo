﻿using System;
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

        public ClientHomeViewModel() {
            ClientTravelsOverviewCommand = new ClientTravelsOverviewCommand();
            LogOutCommand = new LogOutCommand();
            RegisterHandler();
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("ClientTravelsOverview", () =>
            {
                TravelsOverviewViewModel TravelsOverviewViewModel = ServiceLocator.Get<TravelsOverviewViewModel>();
                SwitchCurrentViewModel(TravelsOverviewViewModel);
            });
        }

    }
}
