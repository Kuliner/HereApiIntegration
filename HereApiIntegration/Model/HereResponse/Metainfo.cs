using System;

namespace HereApiIntegration.Model.HereResponse
{
    public class Metainfo
    {
        public DateTime Timestamp { get; set; }
        public string MapVersion { get; set; }
        public string ModuleVersion { get; set; }
        public string InterfaceVersion { get; set; }
        public string[] AvailableMapVersion { get; set; }
    }

}
