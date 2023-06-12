using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismo.Core.Model.Helper;

namespace Tourismo.Core.Persistence
{
    public class DatabaseContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<User> Users { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Arrangement> Arrangements { get; set; }
        public DbSet<TouristAttraction> TouristAttractions { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<DateRange> DateRange { get; set; }

        public DatabaseContext(string path = "") {
            DbPath = path;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root123;database=tourismodb");
        }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Travel>()
                .HasMany(t => t.DefaultAttractions)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "DefaultAttractionTravels",
                    j => j
                        .HasOne<TouristAttraction>()
                        .WithMany()
                        .HasForeignKey("DefaultAttractionId"),
                    j => j
                        .HasOne<Travel>()
                        .WithMany()
                        .HasForeignKey("TravelId")
                );

            modelBuilder.Entity<Travel>()
                .HasMany(t => t.AdditionalAttractions)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AdditionalAttractionTravels",
                    j => j
                        .HasOne<TouristAttraction>()
                        .WithMany()
                        .HasForeignKey("AdditionalAttractionId"),
                    j => j
                        .HasOne<Travel>()
                        .WithMany()
                        .HasForeignKey("TravelId")
                );

            modelBuilder.Entity<Arrangement>()
                .HasMany(t => t.AdditionalAttractions)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AdditionalAttractionArrangements",
                    j => j
                        .HasOne<TouristAttraction>()
                        .WithMany()
                        .HasForeignKey("AdditionalAttractionId"),
                    j => j
                        .HasOne<Arrangement>()
                        .WithMany()
                        .HasForeignKey("ArrangementId")
                );
        }
    }
}
