using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{

    [Table("City", Schema = "Master")]
    public class City
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int CountryRefId { get; set; }

        [ForeignKey(nameof(CountryRefId))]
        public Country? CountryRef { get; set; }
    }
}
