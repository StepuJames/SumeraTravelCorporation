using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table(name: "fligh_schedule")]
    public class FlightSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
 

        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }


    }
}




