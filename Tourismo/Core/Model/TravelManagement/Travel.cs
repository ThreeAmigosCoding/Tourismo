using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.TravelManagement
{
    public class Travel : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        [ForeignKey("DefaultAttractionId")]
        private List<TouristAttraction> _defaultAttractions;
        public virtual List<TouristAttraction> DefaultAttractions { get => _defaultAttractions; set => OnPropertyChanged(ref _defaultAttractions, value); }

        [ForeignKey("AdditionalAttractionId")]
        private List<TouristAttraction> _additionalAttractions;
        public virtual List<TouristAttraction> AdditionalAttractions { get => _additionalAttractions; set => OnPropertyChanged(ref _additionalAttractions, value); }

        private Accommodation _accommodation;
        public virtual Accommodation Accommodation { get => _accommodation; set => OnPropertyChanged(ref _accommodation, value); }

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
