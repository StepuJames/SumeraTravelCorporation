using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sumera.Data.Models.MasterModels
{
    [Table(name: "hotel_room", Schema = "Master")]
    public class HotelRooms
    {
        [Key]
        public int Id { get; set; }
        [Required]
         
        public int HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel? Hotel { get; set; }

        [Required]
     
        public int RoomRefId { get; set; }
        [ForeignKey(nameof(RoomRefId))]

        public Room? Room { get; set; }
        

         
        public int PerNight { get; set; }

         
        public int PerDay { get; set; }
     
        public int PerDayNight { get; set; }

    }
}
