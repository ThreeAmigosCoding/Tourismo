using System.Collections.Generic;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.TravelManagement
{
    public class Arrangement : BaseObservableEntity
    {
        private User _traveler;
        public User Traveler { get => _traveler; set => OnPropertyChanged(ref _traveler, value); }

        private Travel _travel;
        public Travel Travel { get => _travel; set  => OnPropertyChanged(ref _travel, value); }

        private List<Accommodation> _accommodations;
        public List<Accommodation> Accommodations { get => _accommodations; set => OnPropertyChanged(ref _accommodations, value); }

        private List<TouristAttraction> _additionalAttractions;
        public List<TouristAttraction> AdditionalAttractions { get => _additionalAttractions; set => OnPropertyChanged(ref _additionalAttractions, value); }

        private DateRange _period;
        public DateRange Period { get => _period; set => OnPropertyChanged(ref _period, value); }

        private double _price;
        public double Price { get => _price; set => OnPropertyChanged(ref _price, value); }

        private ArrangementStatus _arrangementStatus;
        public ArrangementStatus ArrangementStatus { get => _arrangementStatus; set =>  OnPropertyChanged(ref _arrangementStatus, value); }
    }
}
