using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserDocumentation;
using Tourismo.Core.Model.UserManagement;

namespace Tourismo.Core.Persistence
{
    public class DatabaseContextSeed
    {
        public static void Seed(DatabaseContext context)
        {
            SeedUsers(context);
            SeedAccommodations(context);
            SeedTouristAttractions(context);
            SeedTravels(context);
            SeedArrangements(context);
            SeedDocumentation(context);
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
            new User
            {
                EmailAddress = "user3@example.com",
                Password = "password3",
                FirstName = "Pera",
                LastName = "Perić",
                Phone = "987654321",
                Role = Role.Client
            },
            new User
            {
                EmailAddress = "user4@example.com",
                Password = "password4",
                FirstName = "Mika",
                LastName = "Mikić",
                Phone = "987654321",
                Role = Role.Client
            },
            new User
            {
                EmailAddress = "milos@example.com",
                Password = "milos123",
                FirstName = "Miloš",
                LastName = "Čuturić",
                Phone = "987654321",
                Role = Role.Agent
            },
            new User
            {
                EmailAddress = "luka@example.com",
                Password = "luka123",
                FirstName = "Luka",
                LastName = "Đorđević",
                Phone = "987654321",
                Role = Role.Agent
            },
            new User
            {
                EmailAddress = "marko@example.com",
                Password = "marko123",
                FirstName = "Marko",
                LastName = "Janošević",
                Phone = "987654321",
                Role = Role.Agent
            }          
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
                Name = "Rtanj",
                Description = "Planina Rtanj – Srpska piramida, misterije, svetilište. Poznato je da je istočna Srbija veoma bogata prirodom. Tako je u tom delu Srbije smeštena i srpska „piramida“ – planina Rtanj. Planina Rtanj se nalazi u Zaječarskom okrugu, u blizini Boljevca.",
                ImagePath = "TouristAttraction/rtanj.jpg",
                Price = 5000.0,
                Location = new Location
                {
                    Address = "Rtanj",
                    Latitude = 43.77269,
                    Longitude = 21.87629
                }
            },
            new TouristAttraction
            {
                Name = "Manastir Lozica",
                Description = "U ataru sela Krivi Vir, na nešto više tri kilometara od samog sela, nalazi se manastir Lozica, koji je posvećen Arhangelu Gavrilu.",
                ImagePath = "TouristAttraction/manastirLozica.jpg",
                Price = 500.0,
                Location = new Location
                {
                    Address = "Krivi Vir",
                    Latitude = 43.79979,
                    Longitude = 21.75992
                }
            },
            new TouristAttraction
            {
                Name = "Homoljske planine",
                Description = "Za Homoljske planine vezuju se brojne legende i mistične priče. U njih možemo da sumnjamo, ali u lepotu ovog kraja, sigurne ne.",
                ImagePath = "TouristAttraction/homoljskePlanine.jpg",
                Price = 2500.0,
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
                Description = "Manastir Gornjak leži na manjem, proširenom platou Mlave u Gornjačkoj klisuri. Prislonjen je uz kamene litice Ježevca ispod kojih promiče brza i bistra Mlava.",
                ImagePath = "TouristAttraction/manastirGornjak.jpg",
                Price = 500.0,
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
                Description = "Banja Ždrelo ili pak Mlavske Terme, banja nadomak Petrovaca na Mlavi koja pleni svojim jedinstvenim mogućnostima i sadržajem.",
                ImagePath = "TouristAttraction/banjaZdrelo.jpg",
                Price = 1000.0,
                Location = new Location
                {
                    Address = "Ždrelo, 66, Ždrelo 12300",
                    Latitude = 44.30689,
                    Longitude = 21.48383
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
                Name = "Rtanj",
                DefaultAttractions = context.TouristAttractions.Where(a => a.Name == "Rtanj").ToList(),
                AdditionalAttractions = context.TouristAttractions.Where(a => a.Name == "Manastir Lozica").ToList(),
                Accommodation = context.Accommodations.Where(a => a.Name == "Konak Ljubica").First(),
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
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(50),
                        EndDate = DateTime.Now.AddDays(55)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(60),
                        EndDate = DateTime.Now.AddDays(65)
                    }
                },
                ImagePath = "Travel/rtanj.jpg",
                MinimalPrice = 5000.0,
                ShortDescription = "Avantura počinje! Noćno penjanje i čekanje izlaska sunca na vrhu Šiljak."
            },
            new Travel
            {
                Name = "Homoljske planine",
                DefaultAttractions = context.TouristAttractions.Where(a => a.Name == "Homoljske planine" || a.Name == "Manastir Gornjak").ToList(),
                AdditionalAttractions = context.TouristAttractions.Where(a => a.Name == "Banja Ždrelo").ToList(),
                Accommodation = context.Accommodations.Where(a => a.Name == "Kod Rajka").First(),
                Periods = new List<DateRange>
                {
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(10),
                        EndDate = DateTime.Now.AddDays(13)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(20),
                        EndDate = DateTime.Now.AddDays(23)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(30),
                        EndDate = DateTime.Now.AddDays(33)
                    },
                    new DateRange
                    {
                        StartDate = DateTime.Now.AddDays(40),
                        EndDate = DateTime.Now.AddDays(43)
                    }
                },
                ImagePath = "Travel/homoljskePlanine.jpg",
                MinimalPrice = 3000.0,
                ShortDescription = "Vodimo Vas u predele Istočne Srbije gde otkrivamo šta videti na Homoljskim planinama. Pored predivne prirode, obilazimo manastir Gornjak, reku Mlavu, banju Ždrelo i uživamo u pogledu sa vrha Ježevca."
            }
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
                Name = "Kod Rajka",
                ImagePath = "Accommodation/kodRajka.jpg",
                Price = 100.0,
                Location = new Location
                {
                    Address = "161 Ždrelo RS, 12300",
                    Latitude = 44.27481,
                    Longitude = 21.52464
                },
                Type = AccommodationType.Restaurant
            },
            new Accommodation
            {
                Name = "Konak Ljubica",
                ImagePath = "Accommodation/konakLjubica.jpg",
                Price = 200.0,
                Location = new Location
                {
                    Address = "Mirovo b.b, Mirovo 19370",
                    Latitude = 43.81318,
                    Longitude = 21.88434
                },
                Type = AccommodationType.LogCabbin
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
                Traveler = context.Users.FirstOrDefault(u => u.EmailAddress == "user1@example.com"),
                Travel = context.Travels.FirstOrDefault(t => t.Name == "Rtanj"),
                AdditionalAttractions = context.TouristAttractions.Where(t => t.Name == "Manastir Lozica").ToList(),
                Period = new DateRange
                {
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(45)
                },
                Price = 5500.0,
                ArrangementStatus = ArrangementStatus.Reserved
            },
            new Arrangement
            {
                Traveler = context.Users.FirstOrDefault(u => u.EmailAddress == "user3@example.com"),
                Travel = context.Travels.FirstOrDefault(t => t.Name == "Rtanj"),
                AdditionalAttractions = new List<TouristAttraction>(),
                Period = new DateRange
                {
                    StartDate = DateTime.Now.AddDays(40),
                    EndDate = DateTime.Now.AddDays(45)
                },
                Price = 5000.0,
                ArrangementStatus = ArrangementStatus.Reserved
            },
            // Add more arrangement objects here
        };

            context.Arrangements.AddRange(arrangements);
            context.SaveChanges();
        }

        private static void SeedDocumentation(DatabaseContext context)
        {
            var documentation = new List<UserDocumentation>
            {
                new UserDocumentation
                {
                    Name = "Agent documentation v01",
                    Type = UserDocumentationType.AgentDocumentation,
                    Sections =  new List<UserDocumentationSection>
                    {
                        new UserDocumentationSection
                        {
                            Name = "Agent placeholder title",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ImagePath = "Documentation/documentation.png"
                        },
                        new UserDocumentationSection
                        {
                            Name = "Agent lorem ipsum",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ImagePath = "Documentation/documentation.png"
                        }
                    }
                },

                new UserDocumentation
                {
                    Name = "Client documentation v01",
                    Type = UserDocumentationType.ClientDocumentation,
                    Sections =  new List<UserDocumentationSection>
                    {
                        new UserDocumentationSection
                        {
                            Name = "Client placeholder title",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ImagePath = "Documentation/documentation.png"
                        },
                        new UserDocumentationSection
                        {
                            Name = "Client lorem ipsum",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ImagePath = "Documentation/documentation.png"
                        }
                    }
                },

            };

            context.UserDocumentation.AddRange(documentation);
            context.SaveChanges();

        }

    }
}
