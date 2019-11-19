using System.Collections.Generic;
using System.IO;
using HereApiIntegration.Definitions.Options;
using HereApiIntegration.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HereApiIntegration.Repositories
{
    public class JsonRouteRepository : IJsonRouteRepository
    {
        private readonly string _jsonRepositoryPath;

        public JsonRouteRepository(IOptions<JsonRepositoryPath> options)
        {
            _jsonRepositoryPath = options.Value.Path;
        }

        public IEnumerable<JsonRoute> GetAll()
        {
            var routes = new List<JsonRoute>();
            var serializer = new JsonSerializer();

            foreach (string fileName in Directory.GetFiles(_jsonRepositoryPath, "*.json"))
            {
                using (StreamReader streamReader = File.OpenText(fileName))
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    var route = new JsonRoute
                    {
                        Waypoints = serializer.Deserialize<List<JsonWaypoint>>(jsonTextReader)
                    };

                    routes.Add(route);
                }
            }

            return routes;
        }
    }
}
