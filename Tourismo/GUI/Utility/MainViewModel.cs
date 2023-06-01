using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.GUI.Auth;
using Tourismo.Core.Ninject;
using System.Runtime.Intrinsics.Arm;
using Tourismo.GUI.Navigation;

namespace Tourismo.GUI.Utility
{
    public class MainViewModel : NavigableViewModel
    {
        private string _viewTitle;
        public string ViewTitle
        {
            get => _viewTitle;
        }
        private void OnTitleChanged()
        {
            _viewTitle = TitleManager.Title;
            OnPropertyChanged(nameof(ViewTitle));
        }

        public LoginViewModel LVM { get; set; }

        public RegistrationViewModel RVM { get; set; }

        public MainViewModel(LoginViewModel loginVM, RegistrationViewModel registrationVM)
        {
            TitleManager.TitleChanged += OnTitleChanged;
            TitleManager.Title = "Tourismo";
            LVM = loginVM;
            RVM = registrationVM;
            SwitchCurrentViewModel(LVM);
            RegisterHandler(); 
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("ClientLogin", () =>
            {
                ClientHomeViewModel ClientHomeViewModel = ServiceLocator.Get<ClientHomeViewModel>();
                SwitchCurrentViewModel(ClientHomeViewModel);
            });

            EventBus.RegisterHandler("AgentLogin", () =>
            {
                AgentHomeViewModel AgentHomeViewModel = ServiceLocator.Get<AgentHomeViewModel>();
                SwitchCurrentViewModel(AgentHomeViewModel);
            });

            EventBus.RegisterHandler("GoToLogin", () =>
            {
                EventBus.Clear();
                ServiceLocator.Reset();
                LVM = ServiceLocator.Get<LoginViewModel>();
                SwitchCurrentViewModel(LVM);
                RegisterHandler();
            });

            EventBus.RegisterHandler("GoToRegistration", () =>
            {
                EventBus.Clear();
                ServiceLocator.Reset();
                RVM = ServiceLocator.Get<RegistrationViewModel>();
                SwitchCurrentViewModel(RVM);
                RegisterHandler();
            });
        }
    }
}
