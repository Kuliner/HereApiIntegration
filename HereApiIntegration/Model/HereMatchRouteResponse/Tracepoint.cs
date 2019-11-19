namespace HereApiIntegration.Model.HereMatchRouteResponse
{
    public class Tracepoint
    {
        public float ConfidenceValue { get; set; }
        public float Elevation { get; set; }
        public float HeadingDegreeNorthClockwise { get; set; }
        public float HeadingMatched { get; set; }
        public float Lat { get; set; }
        public float LatMatched { get; set; }
        public int LinkIdMatched { get; set; }
        public float Lon { get; set; }
        public float LonMatched { get; set; }
        public float MatchDistance { get; set; }
        public float MatchOffsetOnLink { get; set; }
        public float MinError { get; set; }
        public int EouteLinkSeqNrMatched { get; set; }
        public float SpeedMps { get; set; }
        public int Timestamp { get; set; }
    }

}
