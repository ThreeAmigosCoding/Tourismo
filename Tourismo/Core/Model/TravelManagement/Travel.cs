using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.TravelManagement
{
    public class Travel : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private List<Section> _sections;
        public virtual List<Section> Sections { get => _sections; set => OnPropertyChanged(ref _sections, value); }

        private List<DateRange> _periods;
        public virtual List<DateRange> Periods { get => _periods; set => OnPropertyChanged(ref _periods, value); }

        private string _imagePath;
        public string ImagePath { get => _imagePath; set => OnPropertyChanged(ref _imagePath, value); }

        private double _minimalPrice;
        public double MinimalPrice { get => _minimalPrice; set => OnPropertyChanged(ref _minimalPrice, value); }

        private string _shortDescription;
        public string ShortDescription { get => _shortDescription; set => OnPropertyChanged(ref _shortDescription, value); }

        public DateRange SoonestPeriod
        {
            get { return CalculateSoonestPeriod(); }
        }

        private DateRange CalculateSoonestPeriod()
        {
            DateTime currentDate = DateTime.Now;
            DateRange soonestPeriod = null;

            foreach (DateRange period in Periods)
            {
                if (period.StartDate > currentDate)
                {
                    soonestPeriod = period;
                    break;
                }
            }

            return soonestPeriod;
        }
    }
}
