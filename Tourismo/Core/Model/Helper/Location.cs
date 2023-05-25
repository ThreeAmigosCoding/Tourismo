
using Microsoft.EntityFrameworkCore;

namespace Tourismo.Core.Model.Helper
{
    [Owned]
    public class Location
    {
        private string _address;
        public string Address { get { return _address; } set { _address = value; } }

        private double _latitude;
        public double Latitude { get { return _latitude; } set { _latitude = value; } }

        private double _longitude;
        public double Longitude { get { return _longitude; } set { _longitude = value; } }
    }
}
