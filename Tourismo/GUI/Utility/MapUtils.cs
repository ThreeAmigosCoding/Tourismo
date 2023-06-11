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
