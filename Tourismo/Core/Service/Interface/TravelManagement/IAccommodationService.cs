using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;

namespace Tourismo.Core.Service.Interface.TravelManagement
{
    public interface IAccommodationService : ICRUDService<Accommodation>
    {
        IEnumerable<Accommodation> ReadAllActive();
        IEnumerable<Accommodation> ReadAllNonRestaurants();

        void Deactivate(Accommodation accommodation);
    }
}
