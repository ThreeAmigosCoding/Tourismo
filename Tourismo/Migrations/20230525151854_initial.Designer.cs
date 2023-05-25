﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tourismo.Core.Persistence;

#nullable disable

namespace Tourismo.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230525151854_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tourismo.Core.Model.Helper.DateRange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("TravelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("DateRange");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ArrangementId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArrangementId");

                    b.HasIndex("SectionId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Arrangement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ArrangementStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TravelerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("TravelId");

                    b.HasIndex("TravelerId");

                    b.ToTable("Arrangements");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TravelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.TouristAttraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ArrangementId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("SectionId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ArrangementId");

                    b.HasIndex("SectionId");

                    b.HasIndex("SectionId1");

                    b.ToTable("TouristAttractions");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("MinimalPrice")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Tourismo.Core.Model.UserManagement.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tourismo.Core.Model.Helper.DateRange", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", null)
                        .WithMany("Periods")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Accommodation", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Arrangement", null)
                        .WithMany("Accommodations")
                        .HasForeignKey("ArrangementId");

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Section", null)
                        .WithMany("Accommodations")
                        .HasForeignKey("SectionId");

                    b.OwnsOne("Tourismo.Core.Model.Helper.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("AccommodationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double");

                            b1.HasKey("AccommodationId");

                            b1.ToTable("Accommodations");

                            b1.WithOwner()
                                .HasForeignKey("AccommodationId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Arrangement", b =>
                {
                    b.HasOne("Tourismo.Core.Model.Helper.DateRange", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", "Travel")
                        .WithMany()
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tourismo.Core.Model.UserManagement.User", "Traveler")
                        .WithMany()
                        .HasForeignKey("TravelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Period");

                    b.Navigation("Travel");

                    b.Navigation("Traveler");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Section", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", null)
                        .WithMany("Sections")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.TouristAttraction", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Arrangement", null)
                        .WithMany("AdditionalAttractions")
                        .HasForeignKey("ArrangementId");

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Section", null)
                        .WithMany("AdditionalAttractions")
                        .HasForeignKey("SectionId");

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Section", null)
                        .WithMany("DefaultAttractions")
                        .HasForeignKey("SectionId1");

                    b.OwnsOne("Tourismo.Core.Model.Helper.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("TouristAttractionId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double");

                            b1.HasKey("TouristAttractionId");

                            b1.ToTable("TouristAttractions");

                            b1.WithOwner()
                                .HasForeignKey("TouristAttractionId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Arrangement", b =>
                {
                    b.Navigation("Accommodations");

                    b.Navigation("AdditionalAttractions");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Section", b =>
                {
                    b.Navigation("Accommodations");

                    b.Navigation("AdditionalAttractions");

                    b.Navigation("DefaultAttractions");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Travel", b =>
                {
                    b.Navigation("Periods");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
