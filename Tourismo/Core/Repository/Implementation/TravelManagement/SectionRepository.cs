using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface.TravelManagement;

namespace Tourismo.Core.Repository.Implementation.TravelManagement
{
    public class SectionRepository : CRUDRepository<Section>, ISectionRepository
    {
        public SectionRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
