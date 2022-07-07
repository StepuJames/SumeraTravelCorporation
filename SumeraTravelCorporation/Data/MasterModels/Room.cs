using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sumera.Data.Models.MasterModels
{
    [Table(name:"rooms", Schema = "MasterData")]
    public class Room
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Column("room_name", TypeName = "varchar(100)")]
        public string Name { get; set; } = null!;
        [Column("room_desciption", TypeName = "varchar(100)")]
        [Required]
        public string Description { get; set; } = null!;

    }
}
