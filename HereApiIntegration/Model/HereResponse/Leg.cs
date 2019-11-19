namespace HereApiIntegration.Model.HereResponse
{
    public class Leg
    {
        public Waypoint Start { get; set; }
        public Waypoint End { get; set; }
        public int Length { get; set; }
        public int TravelTime { get; set; }
        public Maneuver[] Maneuver { get; set; }
    }

}
