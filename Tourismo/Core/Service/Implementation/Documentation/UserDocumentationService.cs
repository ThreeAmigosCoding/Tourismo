using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.UserDocumentation;
using Tourismo.Core.Repository.Interface.Documentation;
using Tourismo.Core.Service.Interface.Documentation;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.Documentation
{
    public class UserDocumentationService : IUserDocumentationService
    {
        private IUserDocumentationRepository _userDocumentationRepository;

        public UserDocumentationService(IUserDocumentationRepository userDocumentationRepository)
        {
            _userDocumentationRepository = userDocumentationRepository;
        }

        public UserDocumentation Create(UserDocumentation entity)
        {
            return _userDocumentationRepository.Create(entity);
        }

        public UserDocumentation Delete(Guid id)
        {
            return _userDocumentationRepository.Delete(id);
        }

        public UserDocumentation Read(Guid id)
        {
            return (_userDocumentationRepository.Read(id));
        }

        public IEnumerable<UserDocumentation> ReadAll()
        {
            return _userDocumentationRepository.ReadAll();
        }

        public UserDocumentation Update(UserDocumentation entity)
        {
            return _userDocumentationRepository.Update(entity);
        }
    }
}
