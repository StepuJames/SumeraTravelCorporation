using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table(name: "flightbooking")]
    public class FlightBooking
    {

        [Key]
        public int Id { get; set; }

        [Required]
      
        public int CustRefId { get; set; }
       
        [Required]
        public DateTime? BookingDate { get; set; }

        
        public int FlightScheduleId { get; set; }
        [ForeignKey(nameof(FlightScheduleId))]

        public FlightSchedule? FlightShcedule { get; set; }

     
        public long ContactNumber { get; set; }

     
        public string? ContactEmail { get; set; } 

      
        public int NumberOfPeople { get; set; }

       
        public int NumberOfTicket { get; set; }
 
        public int TotalAmount { get; set; }

        public List<FlightCustomerDetail>? FlightCustomerDetails { get; set; }


    }
}
