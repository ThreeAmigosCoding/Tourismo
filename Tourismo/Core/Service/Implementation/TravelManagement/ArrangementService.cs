using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.TravelManagement
{
    public class ArrangementService : IArrangementService
    {

        private readonly IArrangementRepository _arrangementRepository;

        public ArrangementService(IArrangementRepository arrangementRepository)
        {
            _arrangementRepository = arrangementRepository;
        }

        public List<Arrangement> GetUserReservations(String email)
        {
            return _arrangementRepository.ReadAll()
                .Where(arrangement => arrangement.Traveler.EmailAddress == email && (arrangement.ArrangementStatus == ArrangementStatus.Reserved || arrangement.ArrangementStatus == ArrangementStatus.Active))
                .OrderBy(arrangement => arrangement.Period.StartDate)
                .ToList();
        }

        #region CRUD Methods

        public Arrangement Create(Arrangement entity)
        {
            return _arrangementRepository.Create(entity);
        }

        public Arrangement Delete(Guid id)
        {
            return _arrangementRepository.Delete(id);
        }

        public Arrangement Read(Guid id)
        {
            return _arrangementRepository.Read(id);
        }

        public IEnumerable<Arrangement> ReadAll()
        {
            return _arrangementRepository.ReadAll();
        }

        public Arrangement Update(Arrangement entity)
        {
            return _arrangementRepository.Update(entity);
        }

        #endregion
    }
}
