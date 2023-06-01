using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.Helper
{
    public class DateRange : BaseObservableEntity
    {
        private DateTime _startDate;
        public DateTime StartDate { get => _startDate; set => OnPropertyChanged(ref _startDate, value); }

        private DateTime _endDate;
        public DateTime EndDate { get => _endDate; set => OnPropertyChanged(ref _endDate, value); }

        public override string ToString()
        {
            string startDateString = _startDate.ToString("MM/dd/yyyy");
            string endDateString = _endDate.ToString("MM/dd/yyyy");
            return startDateString + " - " + endDateString;
        }
    }
}
