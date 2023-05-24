
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.Travel
{
    public class TouristAttraction : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private string _description;
        public string Description { get => _description; set => OnPropertyChanged(ref _description, value); }

        private string _imagePath;
        public string ImagePath { get => _imagePath; set =>  OnPropertyChanged(ref _imagePath, value); }

        private double _price;
        public double Price { get => _price; set => OnPropertyChanged(ref _price, value); }

        private Location _location;
        public Location Location { get => _location; set => OnPropertyChanged(ref _location, value); }


    }
}
