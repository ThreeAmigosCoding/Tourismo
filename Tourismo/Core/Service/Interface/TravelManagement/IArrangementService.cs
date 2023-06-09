using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Service.Interface.TravelManagement
{
    public interface IArrangementService : ICRUDService<Arrangement>
    {
        List<Arrangement> GetUserReservations(String email);
        List<Arrangement> GetUserHistory(String email);

        Dictionary<Travel, int> GetTravelsByMonth(DateTime month);

        Summarry GetSummarryByMonth(DateTime month);
    }
}
