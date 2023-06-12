using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;

namespace Tourismo.Core.Repository.Interface.TravelManagement
{
    public interface ITravelRepository : ICRUDRepository<Travel>
    {
        public Travel CreateNewTravel(Travel travel);
        public Travel UpdateTravel(Travel travel);
    }
}
