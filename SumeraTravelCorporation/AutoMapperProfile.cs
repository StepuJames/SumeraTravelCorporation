using AutoMapper;
using Sumera.Data.Models.MasterModels;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.MasterModels;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Airline, AirlineDto>().ReverseMap();


            CreateMap<Airport, AirportDto>().ReverseMap();
            CreateMap<Airport, AirportDto>()
                .ForMember(dto => dto.City, opt => opt.MapFrom(model => model.CityRef.Name))
                .ReverseMap()
                .ForPath(model => model.CityRef.Name, opt => opt.Ignore());


            CreateMap<Amenities, AmenitiesDto>().ReverseMap();
            CreateMap<City, CityDto>()
                .ForMember(dto=>dto.Country,opt=>opt.MapFrom(model=>model.CountryRef.Name))
                 .ReverseMap()
                .ForPath(model => model.CountryRef.Name, opt => opt.Ignore());

            //.ForMember(dto => dto.CountryRef, opt => opt.MapFrom(model => model.CountryRef.Name)).

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<FlightAmenities, FlightAmenitiesDto>().ReverseMap();
            CreateMap<FlightAmenitiesLink, FlightAmenitiesLinkDto>().ReverseMap();

            CreateMap<Flight, FlightDto>().ReverseMap();
            //CreateMap<Flight, FlightDto>()
            //    .ForMember(dto=>dto.AirlineName,opt=>opt.MapFrom(model=>model.Airline.Name))
            //    .ForMember(dto=>dto.AirportName1,opt=>opt.MapFrom(model=>model.FromAirport))
            //    .ReverseMap()
            //    .ForPath(model=>model.Airline.Name , opt=>opt.Ignore());


            //CreateMap<Hotel, HotelDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>()
                .ForMember(dto=>dto.City,opt=>opt.MapFrom(model=>model.CityRef.Name))
                .ReverseMap()
                .ForPath(model=>model.CityRef.Name,opt=>opt.Ignore());

            //CreateMap<HotelAmenitiesLink, HotelAmenitiesLinkDto>().ReverseMap();
            CreateMap<HotelAmenitiesLink, HotelAmenitiesLinkDto>()
                .ForMember(dto => dto.HotelName, opt => opt.MapFrom(model => model.HotelRef.Name))
                .ForMember(dto => dto.Amenities, opt => opt.MapFrom(model => model.AmenitiesRef.Name))
                .ReverseMap()
                .ForPath(model => model.HotelRef.Name, opt => opt.Ignore())
                .ForPath(model => model.AmenitiesRef.Name, opt => opt.Ignore());


            CreateMap<TravelClass, TravelClassDto>().ReverseMap();
            CreateMap<Room , RoomDto>().ReverseMap();
            CreateMap<HotelRooms , HotelRoomDto>().ReverseMap();
            CreateMap< FlightSchedule , FlightScheduleDto>().ReverseMap();
            CreateMap< FlightBooking , FlightBookingDto>().ReverseMap();
            CreateMap< HotelBooking , HotelBookingDto>().ReverseMap();
            CreateMap< FlightCustomerDetail , FlightCustomerDetailsDto>().ReverseMap();
            CreateMap< HotelCustomerDetails , HotelCustomerDetailsDto>().ReverseMap();



        }
    }
}




