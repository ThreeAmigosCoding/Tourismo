using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface.Help;

namespace Tourismo.Core.Repository.Implementation.Help
{
    public class DateRangeRepository : CRUDRepository<DateRange>, IDateRangeRepository
    {
        public DateRangeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
