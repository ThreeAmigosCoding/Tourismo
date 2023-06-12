using System;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Service.Interface.UserManagement
{
    public interface IUserService
    {
        public User Authenticate(string email, string password);

        public bool Exists(string email);

        public User Create(User user);

        public User Create(String email, String password, String firstName, String lastName, String phone);
    }
}
