
using Microsoft.EntityFrameworkCore;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.Helper
{
    [Owned]
    public class Location : ObservableEntity
    {
        private string _address;
        public string Address { get { return _address; } set { OnPropertyChanged(ref _address, value); } }

        private double _latitude;
        public double Latitude { get { return _latitude; } set { OnPropertyChanged(ref _latitude, value); } }

        private double _longitude;
        public double Longitude { get { return _longitude; } set { OnPropertyChanged(ref _longitude, value); } }
    }
}
