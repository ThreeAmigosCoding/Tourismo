using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Service.Interface.UserManagement
{
    public interface IUserService
    {
        public User Authenticate(string email, string password);
    }
}
