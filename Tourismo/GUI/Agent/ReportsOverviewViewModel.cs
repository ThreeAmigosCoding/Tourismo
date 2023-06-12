using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tourismo.Core.Commands.Navigation;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.Help;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    public class ReportsOverviewViewModel : NavigableViewModel
    {
        #region Attributes
        private IDateRangeService _dateRangeService;
        private IArrangementService _arrangementService;

        private string _selectedMonth;
        private int _selectedYear;

        private Dictionary<Travel, int> _travelsByMonth;
        private Summarry _summarry;
        #endregion

        #region Properties
        public string SelectedMonth 
        { 
            get { return _selectedMonth; } 
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                TravelsByMonth = _arrangementService.GetTravelsByMonth(generateDate());
                Summarry = _arrangementService.GetSummarryByMonth(generateDate());
            }
        }
        public int SelectedYear
        {
            get { return _selectedYear; }
            set 
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                TravelsByMonth = _arrangementService.GetTravelsByMonth(generateDate());
                Summarry = _arrangementService.GetSummarryByMonth(generateDate());
            }
        }

        public Dictionary<Travel, int> TravelsByMonth 
        {
            get { return _travelsByMonth; }
            set
            {
                _travelsByMonth = value;
                OnPropertyChanged(nameof(TravelsByMonth));
            }
        }
        public Summarry Summarry
        {
            get { return _summarry; }
            set
            {
                _summarry = value;
                OnPropertyChanged(nameof(Summarry));
            }
        }

        public List<string> Months { get => generateMonths(); }
        public List<int> Years { get; set; }
        #endregion

        #region Commands
        public ICommand? ArrangementsForTravelCommand { get; }
        #endregion

        public ReportsOverviewViewModel(IDateRangeService dateRangeService, IArrangementService arrangementService) 
        { 
            _dateRangeService = dateRangeService;
            _arrangementService = arrangementService;
            Years = _dateRangeService.AllYears();
            SelectedYear = Years[0];
            SelectedMonth = Months[0];
 
            TravelsByMonth = _arrangementService.GetTravelsByMonth(generateDate());
            Summarry = _arrangementService.GetSummarryByMonth(generateDate());

            ArrangementsForTravelCommand = new AgentArrangementForTravelCommand(this);
        }

        private List<string> generateMonths() 
        { 
            var months = new List<string>();
            months.Add("January");
            months.Add("February");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("June");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");

            return months;
        }

        private DateTime generateDate()
        {
            var cultureInfo = new CultureInfo("en-US");
            string dateString = "12 " + SelectedMonth + " " + SelectedYear.ToString();
            return DateTime.Parse(dateString, cultureInfo);

        }
    }
}
