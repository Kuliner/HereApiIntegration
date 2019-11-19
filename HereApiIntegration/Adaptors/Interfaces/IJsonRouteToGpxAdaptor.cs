using HereApiIntegration.Model;
using HereApiIntegration.Model.GPX;

namespace HereApiIntegration.Adaptors.Interfaces
{
    public interface IJsonRouteToGpxAdaptor
    {
        Gpx Convert(JsonRoute jsonRoute);
    }
}
