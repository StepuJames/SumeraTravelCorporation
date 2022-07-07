namespace SumeraTravelCorporation.Data.TranctionsDto
{
    public class FlightCustomerDetailsDto
    {
         
        public int Id { get; set; }
        

        public string FirstName { get; set; } = null!;
        

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public int FlightBookingId { get; set; }
        

        public int UserRefId { get; set; }


    }
}
