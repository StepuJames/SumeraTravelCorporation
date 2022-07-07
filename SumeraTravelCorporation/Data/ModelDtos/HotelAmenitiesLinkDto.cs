namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelAmenitiesLinkDto
    {
        public int Id { get; set; }
        public int HotelRefId { get; set; }
       
        public string? HotelName { get; set; }
        public int AmenitiesRefId { get; set; }

        public string? Amenities { get; set; }
         
    }
}
