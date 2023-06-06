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
            SeedUsers(context);
            SeedTouristAttractions(context);
            SeedTravels(context);
            SeedAccommodations(context);
            SeedArrangements(context);
        }

        private static void SeedUsers(DatabaseContext context)
        {
            var users = new List<User>
        {
            new User
            {
                EmailAddress = "user1@example.com",
                Password = "password1",
                FirstName = "John",
                LastName = "Doe",
                Phone = "123456789",
                Role = Role.Client
            },
            new User
            {
                EmailAddress = "user2@example.com",
                Password = "password2",
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "987654321",
                Role = Role.Agent
            },
            // Add more user objects here
        };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedTouristAttractions(DatabaseContext context)
        {
            var touristAttractions = new List<TouristAttraction>
        {
            new TouristAttraction
            {
                Name = "Attraction 1",
                Description = "Description for Attraction 1",
                ImagePath = "image1.jpg",
                Price = 10.0,
                Location = new Location
                {
                    Address = "Mise Dimitrijevica 18",
                    Latitude = 123.456,
                    Longitude = 456.789
                }
            },
            new TouristAttraction
            {
                Name = "Attraction 2",
                Description = "Description for Attraction 2",
                ImagePath = "image2.jpg",
                Price = 20.0,
                Location = new Location
                {
                    Address = "Mise Dimitrijevica 18",
                    Latitude = 987.654,
                    Longitude = 654.321
                }
            },
            // Add more tourist attraction objects here
        };

            context.TouristAttractions.AddRange(touristAttractions);
            context.SaveChanges();
        }

        private static void SeedTravels(DatabaseContext context)
        {
            var travels = new List<Travel>
        {
            new Travel
            {
                Name = "Homoljske planine",
                DefaultAttractions = context.TouristAttractions.Take(2).ToList(),
                AdditionalAttractions = context.TouristAttractions.Skip(2).Take(2).ToList(),
                Accommodation = new Accommodation
                {
                    Name = "Accommodation 1",
                    ImagePath = "accommodation1.jpg",
                    Price = 100.0,
                    Location = new Location
                    {
                        Address = "Mise Dimitrijevica 18",
                        Latitude = 123.456,
                        Longitude = 456.789
                    },
                    Type = AccommodationType.Hotel
                },
                Periods = new List<DateRange>
                {
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(10),
                        EndDate = DateTime.Now.AddDays(15)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(20),
                        EndDate = DateTime.Now.AddDays(25)
                    }
                },
                ImagePath = "Travel/homoljskePlanine.jpg",
                MinimalPrice = 50.0,
                ShortDescription = "Short description for Travel 1"
            },
            new Travel
            {
                Name = "Rtanj",
                DefaultAttractions = context.TouristAttractions.Skip(4).Take(2).ToList(),
                AdditionalAttractions = context.TouristAttractions.Skip(6).Take(2).ToList(),
                Accommodation = new Accommodation
                {
                    Name = "Accommodation 2",
                    ImagePath = "accommodation2.jpg",
                    Price = 200.0,
                    Location = new Location
                    {
                        Address = "Mise Dimitrijevica 18",
                        Latitude = 987.654,
                        Longitude = 654.321
                    },
                    Type = AccommodationType.Motel
                },
                Periods = new List<DateRange>
                {
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(30),
                        EndDate = DateTime.Now.AddDays(35)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(40),
                        EndDate = DateTime.Now.AddDays(45)
                    }
                },
                ImagePath = "Travel/rtanj.jpg",
                MinimalPrice = 100.0,
                ShortDescription = "Short description for Travel 2"
            },
            // Add more travel objects here
        };

            context.Travels.AddRange(travels);
            context.SaveChanges();
        }

        private static void SeedAccommodations(DatabaseContext context)
        {
            var accommodations = new List<Accommodation>
        {
            new Accommodation
            {
                Name = "Accommodation 1",
                ImagePath = "accommodation1.jpg",
                Price = 100.0,
                Location = new Location
                {
                    Address = "Mise Dimitrijevica 18",
                    Latitude = 123.456,
                    Longitude = 456.789
                },
                Type = AccommodationType.Hotel
            },
            new Accommodation
            {
                Name = "Accommodation 2",
                ImagePath = "accommodation2.jpg",
                Price = 200.0,
                Location = new Location
                {
                    Address = "Mise Dimitrijevica 18",
                    Latitude = 987.654,
                    Longitude = 654.321
                },
                Type = AccommodationType.Motel
            },
            // Add more accommodation objects here
        };

            context.Accommodations.AddRange(accommodations);
            context.SaveChanges();
        }

        private static void SeedArrangements(DatabaseContext context)
        {
            var arrangements = new List<Arrangement>
        {
            new Arrangement
            {
                Traveler = context.Users.FirstOrDefault(u => u.Role == Role.Client),
                Travel = context.Travels.FirstOrDefault(),
                AdditionalAttractions = context.TouristAttractions.Take(2).ToList(),
                Period = new DateRange
                {
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(15)
                },
                Price = 150.0,
                ArrangementStatus = ArrangementStatus.Active
            },
            new Arrangement
            {
                Traveler = context.Users.FirstOrDefault(u => u.Role == Role.Agent),
                Travel = context.Travels.Skip(1).FirstOrDefault(),
                AdditionalAttractions = context.TouristAttractions.Skip(2).Take(2).ToList(),
                Period = new DateRange
                {
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(25)
                },
                Price = 250.0,
                ArrangementStatus = ArrangementStatus.Reserved
            },
            // Add more arrangement objects here
        };

            context.Arrangements.AddRange(arrangements);
            context.SaveChanges();
        }
    }
}
