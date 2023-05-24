using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.TravelManagement
{
    public class Accommodation : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private double _price;
        public double Price { get => _price; set => OnPropertyChanged(ref _price, value); }

        private Location _location;
        public Location Location { get => _location; set => OnPropertyChanged(ref _location, value); }

        private AccommodationType _type;
        public AccommodationType Type { get => _type; set => OnPropertyChanged(ref _type, value); }
    }
}
