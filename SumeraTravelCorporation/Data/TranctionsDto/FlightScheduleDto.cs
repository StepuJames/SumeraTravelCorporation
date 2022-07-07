namespace SumeraTravelCorporation.Data.TranctionsDto
{
    public class FlightScheduleDto
    {

        public int Id { get; set; }
         
        public int FlightRefId { get; set; }
         
        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }
    }
}
