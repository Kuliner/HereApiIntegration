namespace HereApiIntegration.Model.HereResponse
{
    public class Waypoint
    {
        public string LinkId { get; set; }
        public Position MappedPosition { get; set; }
        public Position OriginalPosition { get; set; }
        public string Type { get; set; }
        public float Spot { get; set; }
        public string SideOfStreet { get; set; }
        public string MappedRoadName { get; set; }
        public string Label { get; set; }
        public int ShapeIndex { get; set; }
        public string Source { get; set; }
    }
}
