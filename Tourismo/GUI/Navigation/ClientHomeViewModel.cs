using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Auth;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;
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

        public ClientHomeViewModel() {
            LogOutCommand = new LogOutCommand();
            RegisterHandler();
        }

        private void RegisterHandler()
        {

        }

    }
}
