﻿// <auto-generated />
using System;
using EasyTravel.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyTravel.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Car", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comfort");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Distance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Unity");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("Distance");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Unity");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("Duration");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Links", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Front");

                    b.Property<string>("Self");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CityName");

                    b.Property<string>("CountryCode");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency");

                    b.Property<string>("PriceColor");

                    b.Property<string>("StringValue");

                    b.Property<string>("Symbol");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<int?>("ArrivalPlaceId");

                    b.Property<int>("BlaBlaCarMonitoringId");

                    b.Property<string>("CarId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("DeparturePlaceId");

                    b.Property<int?>("DistanceId");

                    b.Property<int?>("DurationId");

                    b.Property<int?>("LinksId");

                    b.Property<int?>("PriceId");

                    b.Property<int>("Seats");

                    b.Property<int>("SeatsLeft");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalPlaceId");

                    b.HasIndex("BlaBlaCarMonitoringId");

                    b.HasIndex("CarId");

                    b.HasIndex("DeparturePlaceId");

                    b.HasIndex("DistanceId");

                    b.HasIndex("DurationId");

                    b.HasIndex("LinksId");

                    b.HasIndex("PriceId");

                    b.ToTable("BlaBlaCarTrips");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Bus.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<TimeSpan>("ArrivalTime");

                    b.Property<string>("BookingLink");

                    b.Property<string>("BusCode");

                    b.Property<int>("BusMonitoringId");

                    b.Property<string>("BusName");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<TimeSpan>("DepartureTime");

                    b.Property<int>("Distance");

                    b.Property<string>("From");

                    b.Property<string>("FromCode");

                    b.Property<string>("LocalPointFrom");

                    b.Property<string>("LocalPointTo");

                    b.Property<double>("Price");

                    b.Property<string>("RoundNum");

                    b.Property<string>("To");

                    b.Property<string>("ToCode");

                    b.HasKey("Id");

                    b.HasIndex("BusMonitoringId");

                    b.ToTable("BusTrips");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.GeoName", b =>
                {
                    b.Property<int>("GeoNameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateNames");

                    b.Property<string>("AsciiName");

                    b.Property<string>("FeatureClass");

                    b.Property<string>("FeatureCode");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("GeoNameId");

                    b.ToTable("GeoNames");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.BlaBlaCarMonitoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("From");

                    b.Property<string>("Guid");

                    b.Property<bool>("IsInProcess");

                    b.Property<bool>("IsSuccessful");

                    b.Property<string>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BlaBlaCarMonitoring");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.BusMonitoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("From");

                    b.Property<string>("Guid");

                    b.Property<bool>("IsInProcess");

                    b.Property<bool>("IsSuccessful");

                    b.Property<string>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BusMonitoring");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.RailwayMonitoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("From");

                    b.Property<string>("Guid");

                    b.Property<bool>("IsInProcess");

                    b.Property<bool>("IsSuccessful");

                    b.Property<string>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RailwayMonitoring");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaxDate");

                    b.Property<string>("MinDate");

                    b.HasKey("Id");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Date");

                    b.Property<string>("SortTime");

                    b.Property<DateTime>("SrcDate");

                    b.Property<string>("StationName");

                    b.Property<string>("StationTrain");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllowBooking");

                    b.Property<int>("AllowPrivilege");

                    b.Property<int>("AllowStudent");

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<string>("BookingLink");

                    b.Property<int>("Category");

                    b.Property<int?>("ChildId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("FromId");

                    b.Property<int>("IsCis");

                    b.Property<int>("IsEurope");

                    b.Property<int>("IsTransformer");

                    b.Property<int>("NoReserve");

                    b.Property<string>("Num");

                    b.Property<int>("RailwayMonitoringId");

                    b.Property<int?>("ToId");

                    b.Property<string>("TravelTime");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FromId");

                    b.HasIndex("RailwayMonitoringId");

                    b.HasIndex("ToId");

                    b.ToTable("RailwayTrips");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Letter");

                    b.Property<long>("Places");

                    b.Property<string>("Title");

                    b.Property<int>("TrainId");

                    b.Property<string>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.BlaBlaCar.Trip", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Place", "ArrivalPlace")
                        .WithMany()
                        .HasForeignKey("ArrivalPlaceId");

                    b.HasOne("EasyTravel.Core.Models.Monitoring.BlaBlaCarMonitoring")
                        .WithMany("Trips")
                        .HasForeignKey("BlaBlaCarMonitoringId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Place", "DeparturePlace")
                        .WithMany()
                        .HasForeignKey("DeparturePlaceId");

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Distance", "Distance")
                        .WithMany()
                        .HasForeignKey("DistanceId");

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Duration", "Duration")
                        .WithMany()
                        .HasForeignKey("DurationId");

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Links", "Links")
                        .WithMany()
                        .HasForeignKey("LinksId");

                    b.HasOne("EasyTravel.Core.Models.BlaBlaCar.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Bus.Trip", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Monitoring.BusMonitoring", "Monitoring")
                        .WithMany("Trips")
                        .HasForeignKey("BusMonitoringId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.BlaBlaCarMonitoring", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany("BlaBlaCarMonitoring")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.BusMonitoring", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany("BusMonitoring")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Monitoring.RailwayMonitoring", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany("RailwayMonitoring")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Train", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Railway.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId");

                    b.HasOne("EasyTravel.Core.Models.Railway.Station", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("EasyTravel.Core.Models.Monitoring.RailwayMonitoring", "Monitoring")
                        .WithMany("Trips")
                        .HasForeignKey("RailwayMonitoringId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyTravel.Core.Models.Railway.Station", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("EasyTravel.Core.Models.Railway.Type", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Railway.Train", "Train")
                        .WithMany("Types")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EasyTravel.Core.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
