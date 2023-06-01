using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Persistence
{
    public class DatabaseContextSeed
    {
        public static void Seed(DatabaseContext context)
        {
            User user1 = new User
            {
                EmailAddress = "user1@example.com",
                Password = "password1",
                FirstName = "John",
                LastName = "Doe",
                Phone = "0123456789",
                Role = Role.Client
            };

            User user2 = new User
            {
                EmailAddress = "user2@example.com",
                Password = "password2",
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "0123456789",
                Role = Role.Agent
            };

            
            // Create accommodations
            Accommodation accommodation1 = new Accommodation
            {
                Name = "Kod Rajka",
                Price = 100,
                Location = new Location
                {
                    Address = "161 Ždrelo RS, 12300",
                    Latitude = 44.27481,
                    Longitude = 21.52464
                },
                Type = AccommodationType.Restaurant
            };

            Accommodation accommodation2 = new Accommodation
            {
                Name = "Konak Ljubica",
                Price = 100,
                Location = new Location
                {
                    Address = "Мирово b.b, Mirovo 19370",
                    Latitude = 43.81318,
                    Longitude = 21.88434
                },
                Type = AccommodationType.LogCabbin
            };



            // Create sections
            Section section1 = new Section
            {
                Name = "Homoljske planine",
                DefaultAttractions = new List<TouristAttraction>
                {
                    new TouristAttraction
                    {
                        Name = "Homoljske planine",
                        Description = "Description 1",
                        Price = 10,
                        ImagePath = "homoljskePlanine.jpg",
                        Location = new Location
                        {
                            Address = "Jošanica",
                            Latitude = 44.33132,
                            Longitude = 21.75847
                             
                        }
                    },
                    new TouristAttraction
                    {
                        Name = "Manastir Gornjak",
                        Description = "Description 2",
                        Price = 20,
                        ImagePath = "manastirGornjak.jpg",
                        Location = new Location
                        {
                            Address = "105, Breznica",
                            Latitude = 44.26608,
                            Longitude = 21.54357
                        }
                    },
                    new TouristAttraction
                    {
                        Name = "Banja Ždrelo",
                        Description = "Description 2",
                        Price = 20,
                        ImagePath = "banjaZdrelo.jpg",
                        Location = new Location
                        {
                            Address = "Zdrelo, 66, Ždrelo 12300",
                            Latitude = 44.30689,
                            Longitude = 21.48383
                        }
                    }
                },
                Accommodations = new List<Accommodation> { accommodation1 }
            };

            Section section2 = new Section
            {
                Name = "Rtanj",
                DefaultAttractions = new List<TouristAttraction>
                {
                    new TouristAttraction
                    {
                        Name = "Rtanj",
                        Description = "Description 1",
                        Price = 10,
                        ImagePath = "rtanj.jpg",
                        Location = new Location
                        {
                            Address = "Rtanj",
                            Latitude = 43.77269,
                            Longitude = 21.87629

                        }
                    }         
                },
                Accommodations = new List<Accommodation> { accommodation2 }
            };

            // Create travel
            Travel travel1 = new Travel
            {
                Name = "Homoljske planine",
                Sections = new List<Section> { section1 },
                Periods = new List<DateRange>
                {
                    new DateRange { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(9) },
                    new DateRange { StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(23) }
                },
                ImagePath = "homoljskePlanine.jpg",
                MinimalPrice = 500,
                ShortDescription = "We take you to the regions of Eastern Serbia, where we discover what to see in the Homolj mountains."
            };

            Travel travel2 = new Travel
            {
                Name = "Rtanj",
                Sections = new List<Section> { section2 },
                Periods = new List<DateRange>
                {
                    new DateRange { StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(7) },
                    new DateRange { StartDate = DateTime.Now.AddDays(12), EndDate = DateTime.Now.AddDays(16) }
                },
                ImagePath = "rtanj.jpg",
                MinimalPrice = 600,
                ShortDescription = "The adventure begins! Night climbing and waiting for the sunrise on top of Šiljak."
            };

            Travel travel3 = new Travel
            {
                Name = "Travel 3",
                Sections = new List<Section> { section1 },
                Periods = new List<DateRange>
                {
                    new DateRange { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(14) },
                    new DateRange { StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(21) }
                },
                ImagePath = "travel1.jpg",
                MinimalPrice = 700,
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            };

            Travel travel4 = new Travel
            {
                Name = "Travel 4",
                Sections = new List<Section> { section1 },
                Periods = new List<DateRange>
                {
                    new DateRange { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(7) },
                    new DateRange { StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(16) }
                },
                ImagePath = "travel1.jpg",
                MinimalPrice = 400,
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            };

            // Create arrangement
            Arrangement arrangement1 = new Arrangement
            {
                Traveler = user1,
                Travel = travel1,
                Accommodations = new List<Accommodation> { accommodation1 },
                AdditionalAttractions = new List<TouristAttraction>{},
                Period = new DateRange { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(9) },
                Price = 500,
                ArrangementStatus = ArrangementStatus.Reserved
            };

            Arrangement arrangement2 = new Arrangement
            {
                Traveler = user1,
                Travel = travel2,
                Accommodations = new List<Accommodation> { accommodation2 },
                AdditionalAttractions = new List<TouristAttraction>{},
                Period = new DateRange { StartDate = DateTime.Now.AddDays(12), EndDate = DateTime.Now.AddDays(17) },
                Price = 600,
                ArrangementStatus = ArrangementStatus.Reserved
            };

            Arrangement arrangement3 = new Arrangement
            {
                Traveler = user1,
                Travel = travel1,
                Accommodations = new List<Accommodation> { accommodation1 },
                AdditionalAttractions = new List<TouristAttraction> { },
                Period = new DateRange { StartDate = DateTime.Now.AddDays(-30), EndDate = DateTime.Now.AddDays(-22) },
                Price = 500,
                ArrangementStatus = ArrangementStatus.Finished
            };

            Arrangement arrangement4 = new Arrangement
            {
                Traveler = user1,
                Travel = travel3,
                Accommodations = new List<Accommodation> { },
                AdditionalAttractions = new List<TouristAttraction> { },
                Period = new DateRange { StartDate = DateTime.Now.AddDays(-40), EndDate = DateTime.Now.AddDays(-34) },
                Price = 700,
                ArrangementStatus = ArrangementStatus.Finished
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Accommodations.Add(accommodation1);
            context.Sections.Add(section1);
            context.Travels.Add(travel1);
            context.Travels.Add(travel2);
            context.Travels.Add(travel3);
            context.Travels.Add(travel4);
            context.Arrangements.Add(arrangement1);
            context.Arrangements.Add(arrangement2);
            context.Arrangements.Add(arrangement3);
            context.SaveChanges();
        }
    }
}
