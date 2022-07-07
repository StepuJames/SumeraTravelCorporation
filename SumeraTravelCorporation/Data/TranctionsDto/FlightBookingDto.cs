using SumeraTravelCorporation.Data.TranctionModels;

namespace SumeraTravelCorporation.Data.TranctionsDto
{
    public class FlightBookingDto
    {
        
        public int Id { get; set; }

       

        public int CustRefId { get; set; }

     
        public DateTime BookingDate { get; set; }


        public int FlightScheduleId { get; set; }
       

        


        public long ContactNumber { get; set; }


        public  string ContactEmail { get; set; }


        public int NumberOfPeople { get; set; }


        public int NumberOfTicket { get; set; }

        public int TotalAmount { get; set; }

      
    }
}
