using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface.TravelManagement;

namespace Tourismo.Core.Repository.Implementation.TravelManagement
{
    public class TravelRepository : CRUDRepository<Travel>, ITravelRepository
    {
        public TravelRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
