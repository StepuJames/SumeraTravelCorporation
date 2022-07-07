using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.MasterModels
{
    [Table(name: "TravelClass", Schema = "MasterData")]
    public class TravelClass
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = null!;




    }
}
