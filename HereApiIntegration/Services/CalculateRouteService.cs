using HereApiIntegration.Definitions.Helpers;
using HereApiIntegration.Definitions.Options;
using HereApiIntegration.Model;
using HereApiIntegration.Model.HereResponse;
using HereApiIntegration.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HereApiIntegration.Services
{
    public class CalculateRouteService : ICalculateRouteService
    {
        private readonly string _mode = "fastest;car;traffic:disabled";
        private readonly string _calculateRouteUrl = "https://route.api.here.com/routing/7.2/calculateroute.json";
        private readonly HereAPICredentials _hereAPICredentials;
        private readonly IHttpClientFactory _httpClientFactory;

        public CalculateRouteService(IHttpClientFactory httpClientFactory, IOptions<HereAPICredentials> hereAPICredentialsOptions)
        {
            _hereAPICredentials = hereAPICredentialsOptions.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HereResponse> CalculateRoute(List<Point> points, string language)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var query = BuildCalculateRouteQuery(points, language);

                var result = await client.GetAsync(query);
                return JsonConvert.DeserializeObject<HereResponse>(await result.Content.ReadAsStringAsync());
            }
        }

        private string BuildCalculateRouteQuery(List<Point> points, string language)
        {
            return _calculateRouteUrl +
                $"?app_id={_hereAPICredentials.AppId}" +
                $"&app_code={_hereAPICredentials.AppCode}" +
                WaypointsQueryHelper.ConvertToHereWaypoints(points) +
                $"&mode={_mode}" +
                $"&language={language}";
        }
    }
}
