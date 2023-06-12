using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Utility
{
    public static class MapUtils
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string _mapKey = MyMapCredentials.MAP_API_KEY;

        public static async Task<string> GetAddressFromLocation(Location location)
        {
            string apiUrl = "http://dev.virtualearth.net/REST/v1/Locations/" 
                + location.Latitude.ToString().Replace(",",".") + "," + location.Longitude.ToString().Replace(",", ".")
                + "?key=" + _mapKey;

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                BingMapsResponse data = JsonConvert.DeserializeObject<BingMapsResponse>(responseBody);

                Address address = data.ResourceSets[0].Resources[0].Address;

                if (address.CountryRegion != "Serbia" && address.CountryRegion != "Kosovo")
                {
                    MessageBox.Show("We only operate in Serbia.");
                    return "";
                }

                return address.AddressLine + ", " + address.Locality;
            }

            return "";

        }

        public static async Task<Location> GetLocationFromAddress(string address)
        {
            string encodedAddress = Uri.EscapeDataString(address + ", Serbia");

            string apiUrl = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedAddress}&key={_mapKey}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                BingMapsResponse data = JsonConvert.DeserializeObject<BingMapsResponse>(responseBody);

                if (data.ResourceSets.Count > 0 && data.ResourceSets[0].Resources.Count > 0)
                {
                    LocationResource locationResource = data.ResourceSets[0].Resources[0];
                    PointUtil point = locationResource.Point;

                    double latitude = point.Coordinates[0];
                    double longitude = point.Coordinates[1];

                    return new Location(latitude, longitude);
                }
            }

            return null;
        }

        public static List<Accommodation> GetRestaurantsWithinRadius(List<Accommodation> allRestaurants, 
            double targetLatitude, 
            double targetLongitude, 
            double radiusInKilometers)
        {
            List<Accommodation> restaurantsWithinRadius = new List<Accommodation>();

            foreach (Accommodation restaurant in allRestaurants)
            {
                double distance = CalculateDistance(targetLatitude, targetLongitude, restaurant.Location.Latitude, restaurant.Location.Longitude);

                if (distance <= radiusInKilometers)
                {
                    restaurantsWithinRadius.Add(restaurant);
                }
            }

            return restaurantsWithinRadius;
        }

        public static double CalculateDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            const double earthRadiusInKilometers = 6371.0;

            double dLat = ConvertToRadians(latitude2 - latitude1);
            double dLon = ConvertToRadians(longitude2 - longitude1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ConvertToRadians(latitude1)) * Math.Cos(ConvertToRadians(latitude2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadiusInKilometers * c;
            return distance;
        }

        public static double ConvertToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

    }

    public class BingMapsResponse
    {
        [JsonProperty("resourceSets")]
        public List<ResourceSet> ResourceSets { get; set; }
    }

    public class ResourceSet
    {
        [JsonProperty("estimatedTotal")]
        public int EstimatedTotal { get; set; }

        [JsonProperty("resources")]
        public List<LocationResource> Resources { get; set; }
    }

    public class LocationResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("point")]
        public PointUtil Point { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class PointUtil
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Address
    {
        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }

        [JsonProperty("adminDistrict")]
        public string AdminDistrict { get; set; }

        [JsonProperty("adminDistrict2")]
        public string AdminDistrict2 { get; set; }

        [JsonProperty("countryRegion")]
        public string CountryRegion { get; set; }

        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
