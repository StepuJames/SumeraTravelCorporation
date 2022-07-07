namespace SumeraTravelCorporation.Data.Dtos
{
    public class CityDto
    {

        public int Id { get; set; }

           
        public string Name { get; set; } = null!;

        public int CountryRefId { get; set; }

        public string? Country { get; set; } 

       
    }
}
