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
    }
}
