using HereApiIntegration.Model;
using HereApiIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HereApiIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteMatchingController : ControllerBase
    {
        private readonly IRouteMatchingService _routeMatchingService;

        public RouteMatchingController(IRouteMatchingService routeMatchingService)
        {
            _routeMatchingService = routeMatchingService;
        }

        [HttpGet("{id}")]
        public ActionResult<JsonRoute> GetById(int id)
        {
            var route = _routeMatchingService.Get(id);
            if (route == null)
                return NotFound();
            else
                return Ok(route);
        }

        [HttpGet]
        public ActionResult<IEnumerable<JsonRoute>> GetAllRoutes()
        {
            var routes =  _routeMatchingService.GetAll();
            if (!routes.Any())
                return NotFound();
            else
                return Ok(routes);
        }

        [HttpPut]
        public async Task<ActionResult<string>> MatchRoute([FromBody] JsonRoute jsonRoute)
        {
            var result = await _routeMatchingService.MatchRoute(jsonRoute);

            return Ok(result);
        }
    }
}
