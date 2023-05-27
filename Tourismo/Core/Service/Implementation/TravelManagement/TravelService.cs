using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.TravelManagement
{
    public class TravelService : ITravelService
    {   

        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        #region CRUD Methods

        public Travel Create(Travel entity)
        {
            return _travelRepository.Create(entity);
        }

        public Travel Delete(Guid id)
        {
            return _travelRepository.Delete(id);
        }

        public Travel Read(Guid id)
        {
            return _travelRepository.Read(id);
        }

        public IEnumerable<Travel> ReadAll()
        {
            return _travelRepository.ReadAll();
        }

        public Travel Update(Travel entity)
        {
            return _travelRepository.Update(entity);
        }

        #endregion
    }
}
