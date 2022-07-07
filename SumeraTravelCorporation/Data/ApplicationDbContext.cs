using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.Data.MasterModels;
using SumeraTravelCorporation.Data.TranctionModels;
using Sumera.Data.Models.MasterModels;
using SumeraTravelCorporation.Data.TranctionsDto;


namespace SumeraTravelCorporation.Data
{

    public class ApplicationDbContext : DbContext
    {

        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet< FlightAmenities> FlightAmenities { get; set; }
        public DbSet< FlightAmenitiesLink> FlightAmenitiesLink { get; set; }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRooms> HotelRoom { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<HotelAmenitiesLink > HotelAmenitiesLink { get; set; }

        public DbSet<TravelClass> TravelClass { get; set; }
        public DbSet<FlightBooking> FlightBooking { get; set; }
        public DbSet<FlightCustomerDetail> FlightCustomerDetail { get; set; }
        public DbSet<FlightSchedule> FlightSchedule { get; set; }
        public DbSet<FlightTravel> FlightTravel { get; set; }
        public DbSet<HotelBooking> HotelBooking { get; set; }
        public DbSet<HotelCustomerDetails> HotelCustomerDetails { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        

        

        

        

     



    }
}




