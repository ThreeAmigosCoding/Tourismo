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
                Role = Role.Client
            };

            User user2 = new User
            {
                EmailAddress = "user2@example.com",
                Password = "password2",
                FirstName = "Jane",
                LastName = "Smith",
                Role = Role.Agent
            };

            // Create accommodations
            Accommodation accommodation1 = new Accommodation
            {
                Name = "Hotel A",
                Price = 100,
                Location = new Location
                {
                    Address = "123 Main St",
                    Latitude = 40.1234,
                    Longitude = -75.5678
                },
                Type = AccommodationType.Hotel
            };

            Accommodation accommodation2 = new Accommodation
            {
                Name = "Restaurant B",
                Price = 50,
                Location = new Location
                {
                    Address = "456 Elm St",
                    Latitude = 40.5678,
                    Longitude = -75.1234
                },
                Type = AccommodationType.Restaurant
            };

            // Create sections
            Section section1 = new Section
            {
                Name = "Section 1",
                DefaultAttractions = new List<TouristAttraction>
                {
                    new TouristAttraction
                    {
                        Name = "Attraction 1",
                        Description = "Description 1",
                        Price = 10,
                        ImagePath = "test.jpeg",
                        Location = new Location
                        {
                            Address = "789 Oak St",
                            Latitude = 40.8765,
                            Longitude = -75.4321
                        }
                    },
                    new TouristAttraction
                    {
                        Name = "Attraction 2",
                        Description = "Description 2",
                        Price = 20,
                        ImagePath = "test.jpeg",
                        Location = new Location
                        {
                            Address = "987 Pine St",
                            Latitude = 40.5432,
                            Longitude = -75.8765
                        }
                    }
                },
                Accommodations = new List<Accommodation> { accommodation1, accommodation2 }
            };

            // Create travel
            Travel travel1 = new Travel
            {
                Name = "Travel 1",
                Sections = new List<Section> { section1 },
                Periods = new List<DateRange>
                {
                    new DateRange { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(7) },
                    new DateRange { StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(17) }
                },
                ImagePath = "travel1.jpg",
                MinimalPrice = 500
            };

            // Create arrangement
            Arrangement arrangement1 = new Arrangement
            {
                Traveler = user1,
                Travel = travel1,
                Accommodations = new List<Accommodation> { accommodation1 },
                AdditionalAttractions = new List<TouristAttraction>
                {
                    new TouristAttraction
                    {
                        Name = "Attraction 3",
                        Description = "Description 3",
                        Price = 30,
                        ImagePath = "test.jpeg",
                        Location = new Location
                        {
                            Address = "654 Walnut St",
                            Latitude = 40.9876,
                            Longitude = -75.7890
                        }
                    }
                },
                Period = new DateRange { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(7) },
                Price = 600,
                ArrangementStatus = ArrangementStatus.Reserved
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Accommodations.Add(accommodation1);
            context.Accommodations.Add(accommodation2);
            context.Sections.Add(section1);
            context.Travels.Add(travel1);
            context.Arrangements.Add(arrangement1);
            context.SaveChanges();
        }
    }
}
