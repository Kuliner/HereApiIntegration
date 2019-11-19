using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HereApiIntegration.Adaptors.Interfaces;
using HereApiIntegration.Definitions.Options;
using HereApiIntegration.Model;
using HereApiIntegration.Model.GPX;
using HereApiIntegration.Model.HereMatchRouteResponse;
using HereApiIntegration.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HereApiIntegration.Services
{
    public class RouteMatchingService : IRouteMatchingService
    {
        private readonly IJsonRouteToGpxAdaptor _jsonRouteToGpxAdaptor;
        private readonly IJsonRouteRepository _jsonWaypointsRepository;
        private readonly HereAPICredentials _hereAPICredentials;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _matchRouteUrl = "https://rme.api.here.com/2/matchroute.json";

        public RouteMatchingService(
            IJsonRouteRepository jsonWaypointsRepository,
            IHttpClientFactory clientFactory,
            IOptions<HereAPICredentials> hereAPICredentialsOptions,
            IJsonRouteToGpxAdaptor jsonRouteToGpxAdaptor)
        {
            _jsonRouteToGpxAdaptor = jsonRouteToGpxAdaptor;
            _jsonWaypointsRepository = jsonWaypointsRepository;
            _hereAPICredentials = hereAPICredentialsOptions.Value;
            _clientFactory = clientFactory;
        }

        public JsonRoute Get(int unitId)
        {
            return _jsonWaypointsRepository.GetAll().SingleOrDefault(x => x.Waypoints.First().UnitId == unitId);
        }

        public IEnumerable<JsonRoute> GetAll()
        {
            var jsonRoutes = _jsonWaypointsRepository.GetAll();
            return jsonRoutes;
        }

        public async Task<HereMatchRouteResponse> MatchRoute(JsonRoute jsonRoute)
        {
            using (var httpClient = _clientFactory.CreateClient())
            {
                var xml = "";
                var gpx = _jsonRouteToGpxAdaptor.Convert(jsonRoute);
                var xsSubmit = new XmlSerializer(typeof(Gpx));
                var query = _matchRouteUrl +
                     $"?app_id={_hereAPICredentials.AppId}" +
                     $"&app_code={_hereAPICredentials.AppCode}" +
                     "&routemode=car" +
                     "&filetype=GPX";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings { OmitXmlDeclaration = true }))
                    {
                        xsSubmit.Serialize(writer, gpx);
                        xml = sww.ToString();
                    }
                }

                var httpContent = new StringContent(xml);
                var response = await httpClient.PostAsync(query, httpContent);

                return JsonConvert.DeserializeObject<HereMatchRouteResponse>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
