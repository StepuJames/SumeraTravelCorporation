using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table("hotel_customer_detail")]
    public class HotelCustomerDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
             
        [Column("first_name")]

        public string FirstName { get; set; } = null!;
        [Required]
        [Column("last_name")]
        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        
        public int? HotelRefBookingId { get; set; }

        [ForeignKey(nameof(HotelRefBookingId))]
        public HotelBooking? HotelBooking { get; set; }

       
        public int UserRefId { get; set; }
        [ForeignKey(nameof(UserRefId))]
        public Customer? Customer { get; set; }

    }
}
