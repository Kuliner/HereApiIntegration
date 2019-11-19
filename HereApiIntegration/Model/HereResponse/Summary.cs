namespace HereApiIntegration.Model.HereResponse
{
    public class Summary
    {
        public int Distance { get; set; }
        public int TrafficTime { get; set; }
        public int BaseTime { get; set; }
        public string[] Flags { get; set; }
        public string Text { get; set; }
        public int TravelTime { get; set; }
        public string Type { get; set; }
    }

}
