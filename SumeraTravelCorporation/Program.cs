using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.Services;
using SumeraTravelCorporation.Data.TrancationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
 
builder.Services.AddScoped<ICountryService, CountryServices>();
builder.Services.AddScoped<ICityService, CityServices>();
builder.Services.AddScoped<IHotelService, HotelServices>();
builder.Services.AddScoped<IAmenitiesService, AmenitiesServices>();
builder.Services.AddScoped<IHotelAmenitiesLinkService, HotelAmenitiesLinkServices>();
builder.Services.AddScoped<IAirportServices, AirportServices>();
builder.Services.AddScoped<IAirlineServices, AirlineServices>();
builder.Services.AddScoped<IFlightServices, FlightServices>();
builder.Services.AddScoped<IFlightAmenitiesServices, FlightAmenitiesServices>();
builder.Services.AddScoped<IFlightAmenitiesLinkServices, FlightAmenitiesLinkServices>();
builder.Services.AddScoped<IHotelRoomServices, HotelRoomServices>();
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<ITravelClassServices, TravelClassServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IFlightScheduleServices, FlightScheduleServices>();
builder.Services.AddScoped<IFlightBookingServices, FlightBookingServices>();
builder.Services.AddScoped<IHotelBookingServices, HotelBookingServices>();
builder.Services.AddScoped<IFlightCustomerDetailsServices, FlightCustomerDetailsServices>();
builder.Services.AddScoped<IHotelCustomerDetailsServices, HotelCustomerDetailsServices>();




builder.Services.AddScoped<IFlightCustomerDetailsRepository, FlightCustomerDetailsRepository>();
builder.Services.AddScoped<IHotelCustomerDetailsRepository, HotelCustomerDetailsRepository>();
builder.Services.AddScoped<IFlightScheduleRepository, FlightScheduleRepository>();
builder.Services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
 




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
