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
    internal class TouristAttractionService : ITouristAttractionService
    {

        private readonly ITouristAttractionRepository _touristAttractionRepository;

        public TouristAttractionService(ITouristAttractionRepository touristAttractionRepository)
        {
            _touristAttractionRepository = touristAttractionRepository;
        }



        #region CRUD Methods
        public TouristAttraction Create(TouristAttraction entity)
        {
            return _touristAttractionRepository.Create(entity);
        }

        public TouristAttraction Delete(Guid id)
        {
            return _touristAttractionRepository.Delete(id);
        }

        public TouristAttraction Read(Guid id)
        {
            return _touristAttractionRepository.Read(id);
        }

        public IEnumerable<TouristAttraction> ReadAll()
        {
            return _touristAttractionRepository.ReadAll();
        }

        public TouristAttraction Update(TouristAttraction entity)
        {
            return _touristAttractionRepository.Update(entity);
        }
        #endregion
    }
}
