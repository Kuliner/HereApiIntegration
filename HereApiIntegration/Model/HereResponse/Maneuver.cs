namespace HereApiIntegration.Model.HereResponse
{
    public class Maneuver
    {
        public HereResponse Position { get; set; }
        public string Instruction { get; set; }
        public int TravelTime { get; set; }
        public int Length { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
