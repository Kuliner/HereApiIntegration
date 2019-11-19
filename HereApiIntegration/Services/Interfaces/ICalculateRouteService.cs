using System.Collections.Generic;
using System.Threading.Tasks;
using HereApiIntegration.Model;
using HereApiIntegration.Model.HereResponse;

namespace HereApiIntegration.Services.Interfaces
{
    public interface ICalculateRouteService
    {
        Task<HereResponse> CalculateRoute(List<Point> points, string language);
    }
}
