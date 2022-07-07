namespace SumeraTravelCorporation.Data.Dtos
{
    public class AirportDto
    {
        public int Id { get; set; }

       public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public int CityRefId { get; set; }

        public string? City { get; set; }
        
        
        public string Address1 { get; set; } = null!;

        
        public string? Address2 { get; set; }

        
        public string? Address3 { get; set; }

        
        public string PinCode { get; set; } =null!;

        
        public string Telephone1 { get; set; } = null!;

        
        public string? Telephone2 { get; set; }

         
        public string Email1 { get; set; } = null!;

      
        public string? Email2 { get; set; }

    }
}
