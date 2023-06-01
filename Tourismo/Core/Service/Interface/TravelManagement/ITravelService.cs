using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;

namespace Tourismo.Core.Service.Interface.TravelManagement
{
    public interface ITravelService : ICRUDService<Travel>
    {
        ObservableCollection<Travel> SortByCriteria(ObservableCollection<Travel> travels, string criteria);

        ObservableCollection<Travel> Filter(ObservableCollection<Travel> travels, double minPrice, double maxPrice,
            DateTime minDate, DateTime maxDate);
    }
}
