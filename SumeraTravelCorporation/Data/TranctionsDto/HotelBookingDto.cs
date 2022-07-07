using SumeraTravelCorporation.Data.TranctionModels;

namespace SumeraTravelCorporation.Data.TranctionsDto
{
    public class HotelBookingDto
    {

        
        public int Id { get; set; }

         

        public int CustRefId { get; set; }

        
        public DateTime BookingDate { get; set; }


        public int HotelId { get; set; }
       
 

       
        public DateTime FromDate { get; set; }


        
        public DateTime ToDate { get; set; }

        public int TotalAmount { get; set; }

       
    }
}
