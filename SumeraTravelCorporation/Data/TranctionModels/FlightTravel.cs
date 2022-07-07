using SumeraTravelCorporation.Data.MasterModels;
using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.TranctionModels
{
    [Table(name: "flight_travel")]
    public class FlightTravel
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
        public int FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
        public Flight? Flight { get; set; }

        [Required]
        
        public int TravelClassRefId { get; set; }
        [ForeignKey(nameof(TravelClassRefId))]
        public TravelClass? TravelClass { get; set; }

        
        public int Rent { get; set; }

    }
}
