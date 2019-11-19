using HereApiIntegration.Model;
using HereApiIntegration.Model.HereResponse;
using HereApiIntegration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HereApiIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateRouteController : ControllerBase
    {
        private readonly ICalculateRouteService _calculateRouteService;

        public CalculateRouteController(ICalculateRouteService calculateRouteService)
        {
            _calculateRouteService = calculateRouteService;
        }

        [HttpGet]
        public async Task<ActionResult<HereResponse>> GetRoute([FromQuery]List<string> points, string language)
        {
            var castedPoints = points.Select(x =>
            {
                var p = x.Split(',');
                return new Point() { Longitude = decimal.Parse(p[0]), Latitude = decimal.Parse(p[1]) };
            }).ToList();

            var route = await _calculateRouteService.CalculateRoute(castedPoints, language);
            return route;
        }
    }
}
