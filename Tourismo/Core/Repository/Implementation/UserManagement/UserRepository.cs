using System.Linq;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface.UserManagement;

namespace Tourismo.Core.Repository.Implementation.UserManagement
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public User Authenticate(string email, string password)
        {
            return _entities.FirstOrDefault(u => u.EmailAddress == email && u.Password == password);
        }
    }
}
