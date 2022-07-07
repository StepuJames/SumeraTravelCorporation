using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class AirlineDto
    {
        public int Id { get; set; }

        
        public string Name { get; set; } = null!;

         
        public string? ShortName { get; set; }

        public string? Logo { get; set; }
        [NotMapped]
        public IFormFile? Images { get; set; }


         
        public string Address1 { get; set; } = null!;

        
        public string? Address2 { get; set; }

        
        public string? Address3 { get; set; }

        public int CityRefId { get; set; }
        
        

       
        public int PinCode { get; set; }

        

        public string Telephone1 { get; set; } = null!;

 
        public string? Telephone2 { get; set; }

         
        public string Email1 { get; set; } = null!;

        
        public string? Email2 { get; set; }

    }
}
