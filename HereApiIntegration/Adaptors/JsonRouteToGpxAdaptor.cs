using HereApiIntegration.Adaptors.Interfaces;
using HereApiIntegration.Model;
using HereApiIntegration.Model.GPX;
using System.Linq;

namespace HereApiIntegration.Adaptors
{
    public class JsonRouteToGpxAdaptor : IJsonRouteToGpxAdaptor
    {
        public Gpx Convert(JsonRoute jsonRoute)
        {
            return new Gpx()
            {
                Version = 1.1m,
                Trk = new GpxTrk()
                {
                    Trkseg = jsonRoute.Waypoints.Select(x => new GpxTrkTrkpt() { Lat = x.Latitude, Lon = x.Longitude }).ToList()
                }
            };
        }
    }
}
