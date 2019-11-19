namespace HereApiIntegration.Model.HereResponse
{
    public class Route
    {
        public Waypoint[] Waypoint { get; set; }
        public Mode Mode { get; set; }
        public Leg[] Leg { get; set; }
        public Summary Summary { get; set; }
    }

}
