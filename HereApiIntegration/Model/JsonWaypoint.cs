using System;

namespace HereApiIntegration.Model
{
    public class JsonWaypoint
    {
        public int UnitId { get; set; }
        public DateTime Timedate { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool Ignition { get; set; }
        public bool Engine { get; set; }
        public decimal Speed { get; set; }
        public bool PositionError { get; set; }
        public int Rpm { get; set; }
        public int Direction { get; set; }
        public int Distance { get; set; }
    }
}
