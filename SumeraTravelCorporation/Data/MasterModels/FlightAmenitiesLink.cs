using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{

    [Table("FlightAmenitiesLink", Schema = "Master")]

    public class FlightAmenitiesLink
    {
        public int Id { get; set; }
        public int FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
        public Flight? FlightRef { get; set; }
        public int FlightAmenitiesRefId { get; set; }
        [ForeignKey(nameof(FlightAmenitiesRefId))]
        public FlightAmenities? FlightAmenities { get; set; }

    }
}
