using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Repository.Interface.UserManagement;
using Tourismo.Core.Service.Interface.UserManagement;

namespace Tourismo.Core.Service.Implementation.UserManagement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string email, string password)
        {
            return _userRepository.Authenticate(email, password);
        }

        public bool Exists(string email)
        {
            return _userRepository.Exists(email);
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User Create(string email, string password, string firstName, string lastName, string phone)
        {
            User user = new User
            {
                EmailAddress = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Role = Role.Client
            };
            return _userRepository.Create(user);
        }
    }
}
