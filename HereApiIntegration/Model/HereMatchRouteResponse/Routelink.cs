namespace HereApiIntegration.Model.HereMatchRouteResponse
{
    public class Routelink
    {
        public int LinkId { get; set; }
        public int FunctionalClass { get; set; }
        public float Confidence { get; set; }
        public string Shape { get; set; }
        public float Offset { get; set; }
        public int MSecToReachLinkFromStart { get; set; }
        public float LinkLength { get; set; }
    }

}
