using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.GUI.Auth;
using Tourismo.Core.Ninject;
using System.Runtime.Intrinsics.Arm;

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
            TitleManager.Title = "Login";
            LVM = loginVM;
            RVM = registrationVM;
            SwitchCurrentViewModel(LVM);
            RegisterHandler();
            
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("ClientLogin", () =>
            {

            });

            EventBus.RegisterHandler("AgentLogin", () =>
            {

            });

            EventBus.RegisterHandler("GoToLogin", () =>
            {
                EventBus.Clear();
                ServiceLocator.Reset();
                LVM = ServiceLocator.Get<LoginViewModel>();
                SwitchCurrentViewModel(LVM);
                TitleManager.Title = "Login";
                RegisterHandler();
            });

            EventBus.RegisterHandler("GoToRegistration", () =>
            {
                EventBus.Clear();
                ServiceLocator.Reset();
                RVM = ServiceLocator.Get<RegistrationViewModel>();
                SwitchCurrentViewModel(RVM);
                TitleManager.Title = "Sign Up";
                RegisterHandler();
            });
        }
    }
}
