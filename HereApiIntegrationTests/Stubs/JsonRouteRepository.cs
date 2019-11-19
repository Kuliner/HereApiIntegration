using HereApiIntegration.Model;
using HereApiIntegration.Repositories;
using System.Collections.Generic;

namespace HereApiIntegrationTests.Stubs
{
    public class JsonRouteRepository : IJsonRouteRepository
    {
        public IEnumerable<JsonRoute> GetAll()
        {
            return new List<JsonRoute>() {
                new JsonRoute()
                {
                    Waypoints = new List<JsonWaypoint>()
                    {
                        new JsonWaypoint()
                        {   UnitId=1,
                            Latitude = 5,
                            Longitude = 5
                        },
                        new JsonWaypoint()
                        {   UnitId=1,
                            Latitude = 6,
                            Longitude = 6
                        }
                    }
                },
                new JsonRoute()
                {
                    Waypoints = new List<JsonWaypoint>()
                    {
                        new JsonWaypoint()
                        {   UnitId=2,
                            Latitude = 15,
                            Longitude = 15
                        },
                        new JsonWaypoint()
                        {   UnitId=2,
                            Latitude = 16,
                            Longitude = 16
                        }
                    }
                }
            };
        }
    }
}
