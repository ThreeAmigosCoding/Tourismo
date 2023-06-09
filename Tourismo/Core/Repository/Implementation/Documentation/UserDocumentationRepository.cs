using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserDocumentation;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface;
using Tourismo.Core.Repository.Interface.Documentation;

namespace Tourismo.Core.Repository.Implementation.Documentation
{
    public class UserDocumentationRepository : CRUDRepository<UserDocumentation>, IUserDocumentationRepository
    {
        public UserDocumentationRepository(DatabaseContext context) : base(context)
        {

        }

    }
}
