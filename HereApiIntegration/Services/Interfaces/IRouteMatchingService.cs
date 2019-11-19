using HereApiIntegration.Model;
using HereApiIntegration.Model.HereMatchRouteResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HereApiIntegration.Services
{
    public interface IRouteMatchingService
    {
        JsonRoute Get(int unitId);
        IEnumerable<JsonRoute> GetAll();
        Task<HereMatchRouteResponse> MatchRoute(JsonRoute jsonRoute);
    }
}
