using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Repository.Interface.Help;
using Tourismo.Core.Service.Interface.Help;

namespace Tourismo.Core.Service.Implementation.Help
{
    public class DateRangeService : IDateRangeService
    {
        private readonly IDateRangeRepository _dateRangeRepository;

        public DateRangeService (IDateRangeRepository dateRangeRepository)
        {
            _dateRangeRepository = dateRangeRepository;
        }

        public List<int> AllYears()
        {
            List<int> distinctYears = ReadAll()
               .SelectMany(range => new[] { range.StartDate.Year, range.EndDate.Year })
               .Distinct()
               .OrderByDescending(year => year)
               .ToList();

            return distinctYears;
        }

        #region CRUD methods
        public DateRange Create(DateRange entity)
        {
            return _dateRangeRepository.Create(entity);
        }

        public DateRange Delete(Guid id)
        {
            return _dateRangeRepository.Delete(id);
        }

        public DateRange Read(Guid id)
        {
            return _dateRangeRepository.Read(id);
        }

        public IEnumerable<DateRange> ReadAll()
        {
            return _dateRangeRepository.ReadAll();
        }

        public DateRange Update(DateRange entity)
        {
            return _dateRangeRepository.Update(entity);
        }
        #endregion
    }
}
