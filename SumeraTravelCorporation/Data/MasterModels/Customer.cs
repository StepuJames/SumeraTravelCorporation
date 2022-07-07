using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Customer", Schema = "Master")]

    public class Customer
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]

        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; } = null!;

        [StringLength(100)]
        public string? Address2 { get; set; }

        [StringLength(50)]
        public string? Address3 { get; set; }

        public int CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]
        public City? CityRef { get; set; }

        [StringLength(5)]
        public int PinCode { get; set; }

        [StringLength(15)]
        public string Telephone1 { get; set; } = null!;

        [StringLength(30)]
        public string Email1 { get; set; } = null!;
    }
}
