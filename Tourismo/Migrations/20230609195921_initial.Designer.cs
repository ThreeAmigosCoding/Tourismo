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
    [Migration("20230609195921_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdditionalAttractionArrangements", b =>
                {
                    b.Property<Guid>("AdditionalAttractionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ArrangementId")
                        .HasColumnType("char(36)");

                    b.HasKey("AdditionalAttractionId", "ArrangementId");

                    b.HasIndex("ArrangementId");

                    b.ToTable("AdditionalAttractionArrangements");
                });

            modelBuilder.Entity("AdditionalAttractionTravels", b =>
                {
                    b.Property<Guid>("AdditionalAttractionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("char(36)");

                    b.HasKey("AdditionalAttractionId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("AdditionalAttractionTravels");
                });

            modelBuilder.Entity("DefaultAttractionTravels", b =>
                {
                    b.Property<Guid>("DefaultAttractionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("char(36)");

                    b.HasKey("DefaultAttractionId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("DefaultAttractionTravels");
                });

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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.TouristAttraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id");

                    b.ToTable("TouristAttractions");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AccommodationId")
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

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Tourismo.Core.Model.UserDocumentation.UserDocumentation", b =>
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserDocumentation");
                });

            modelBuilder.Entity("Tourismo.Core.Model.UserDocumentation.UserDocumentationSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<Guid?>("UserDocumentationId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserDocumentationId");

                    b.ToTable("UserDocumentationSections");
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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdditionalAttractionArrangements", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.TouristAttraction", null)
                        .WithMany()
                        .HasForeignKey("AdditionalAttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Arrangement", null)
                        .WithMany()
                        .HasForeignKey("ArrangementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdditionalAttractionTravels", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.TouristAttraction", null)
                        .WithMany()
                        .HasForeignKey("AdditionalAttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", null)
                        .WithMany()
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DefaultAttractionTravels", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.TouristAttraction", null)
                        .WithMany()
                        .HasForeignKey("DefaultAttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", null)
                        .WithMany()
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tourismo.Core.Model.Helper.DateRange", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Travel", null)
                        .WithMany("Periods")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Accommodation", b =>
                {
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

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.TouristAttraction", b =>
                {
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

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Travel", b =>
                {
                    b.HasOne("Tourismo.Core.Model.TravelManagement.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("Tourismo.Core.Model.UserDocumentation.UserDocumentationSection", b =>
                {
                    b.HasOne("Tourismo.Core.Model.UserDocumentation.UserDocumentation", null)
                        .WithMany("Sections")
                        .HasForeignKey("UserDocumentationId");
                });

            modelBuilder.Entity("Tourismo.Core.Model.TravelManagement.Travel", b =>
                {
                    b.Navigation("Periods");
                });

            modelBuilder.Entity("Tourismo.Core.Model.UserDocumentation.UserDocumentation", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
