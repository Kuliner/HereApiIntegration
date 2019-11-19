namespace HereApiIntegration.Model.HereResponse
{
    public class Mode
    {
        public string Type { get; set; }
        public string[] TransportModes { get; set; }
        public string TrafficMode { get; set; }
        public object[] Feature { get; set; }
    }

}
