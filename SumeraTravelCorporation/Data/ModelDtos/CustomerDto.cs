namespace SumeraTravelCorporation.Data.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

       
        public string FirstName { get; set; } = null!;

        

        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        
        public string Address1 { get; set; } = null!;

       
        public string? Address2 { get; set; }
 
        public string? Address3 { get; set; }

        public int CityRefId { get; set; }
         
         

         
        public int PinCode { get; set; }

      
        public string Telephone1 { get; set; } = null!;
         
        public string Email1 { get; set; } = null!;
    }
}
