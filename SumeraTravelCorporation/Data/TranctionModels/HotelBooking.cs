using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table(name: "hotel_booking")]
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
 
        public int CustRefId { get; set; }
 
        [Required]
        public DateTime BookingDate { get; set; }

         
        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]

        public Hotel? hotelRef { get; set; }
       
        [Required(ErrorMessage = "This Feild is Require")]
        public DateTime FromDate { get; set; }

     
        [Required(ErrorMessage = "This Feild is Require")]
        public DateTime ToDate { get; set; }
 
        public int TotalAmount { get; set; }

        public List<HotelCustomerDetails>? HotelCustomerDetails { get; set; }
    }
}
