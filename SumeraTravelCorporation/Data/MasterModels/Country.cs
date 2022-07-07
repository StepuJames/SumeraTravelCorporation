using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Country", Schema = "Master")]

    public class Country
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(5)]
        public string Code { get; set; } = null!;

        [Unicode(false)]
        [StringLength(50)]
        public string Name { get; set; } = null!;
    }
}
