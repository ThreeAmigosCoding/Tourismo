using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;

namespace Tourismo.Core.Service.Interface.Help
{
    public interface IDateRangeService : ICRUDService<DateRange>
    {
        List<int> AllYears();
    }
}
