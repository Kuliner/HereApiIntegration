namespace HereApiIntegration.Model.HereMatchRouteResponse
{
    public class HereMatchRouteResponse
    {
        public Routelink[] RouteLinks { get; set; }
        public Tracepoint[] TracePoints { get; set; }
        public Warning[] Warnings { get; set; }
        public string MapVersion { get; set; }
    }

}
