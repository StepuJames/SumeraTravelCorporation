namespace SumeraTravelCorporation.Data.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public int AirlineRefId { get; set; }

        public string? AirlineName { get; set; }

      
        
    
        public int? FromAirportRefId { get; set; }
        
        public string? AirportName1 { get; set; } 
       
        public int? ToAirportRefId { get; set; }
         
        public string? AirportName2 { get; set; }




        public string Address1 { get; set; } = null!;

       
        public string? Address2 { get; set; }

       
        public string? Address3 { get; set; }

        public int? CityRefId { get; set; }
      
     
         
        public int PinCode { get; set; }

        
        public string Telephone1 { get; set; } = null!;

        
        public string? Telephone2 { get; set; }

         
        public string Email1 { get; set; } = null!;

         
        public string? Email2 { get; set; }

    }
}
