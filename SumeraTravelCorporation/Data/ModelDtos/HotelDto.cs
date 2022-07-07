namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelDto
    {
        public int Id { get; set; }

        
        public string Name { get; set; } = null!;
        public int Star { get; set; }

        public int CityRefId { get; set; }

        public string? City { get; set; }


    }
}



