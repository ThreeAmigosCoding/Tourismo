using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Repository.Interface.UserManagement
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        User Authenticate(string email, string password);
    }
}
