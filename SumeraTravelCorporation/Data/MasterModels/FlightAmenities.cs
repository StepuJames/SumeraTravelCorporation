using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{

    [Table("FlightAmenities", Schema = "Master")]

    public class FlightAmenities
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        [StringLength(200)]
        public string? Description { get; set; }


    }
}
