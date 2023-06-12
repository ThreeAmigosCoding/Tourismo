using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;

namespace Tourismo.Core.Service.Interface.TravelManagement
{
    internal interface ITouristAttractionService : ICRUDService<TouristAttraction>
    {
        IEnumerable<TouristAttraction> ReadAllActive();

        void Deactivate(TouristAttraction attraction);
    }
}
