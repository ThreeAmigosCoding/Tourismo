using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Service.Interface.TravelManagement
{
    public interface IArrangementService : ICRUDService<Arrangement>
    {
        List<Arrangement> GetUserReservations(String email);
        List<Arrangement> GetUserHistory(String email);
    }
}
