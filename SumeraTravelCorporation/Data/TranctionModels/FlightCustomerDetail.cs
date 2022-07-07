using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table(name: "flight_customer_details")]
    public class FlightCustomerDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
        public string FirstName { get; set; } = null!;
        [Required]
         
        public string LastName { get; set; } = null!;

        public int Age { get; set; }
 
        public int FlightBookingId { get; set; }
        [ForeignKey(nameof(FlightBookingId))]
        public FlightBooking? FlightBooking { get; set; }
 
        public int UserRefId { get; set; }
        [ForeignKey(nameof(UserRefId))]
        public Customer? Customer { get; set; }

    }
}

