using HereApiIntegration.Adaptors;
using HereApiIntegration.Definitions.Options;
using HereApiIntegrationTests.Stubs;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HereApiIntegration.Services.Tests
{
    public class RouteMatchingServiceTests
    {
        [Fact()]
        public void GetTest()
        {
            ServicePreparation(out IOptions<HereAPICredentials> hereApiCredentialsOptions, out JsonRouteRepository jsonRepository, out Mock<IHttpClientFactory> httpClientFactoryMoq);

            var service = new RouteMatchingService(jsonRepository, httpClientFactoryMoq.Object, hereApiCredentialsOptions, new JsonRouteToGpxAdaptor());
            var route = service.Get(1);

            Assert.NotNull(route);
            Assert.Equal(1, route.Waypoints[0].UnitId);
        }

        [Fact()]
        public void GetAllTest()
        {
            ServicePreparation(out IOptions<HereAPICredentials> hereApiCredentialsOptions, out JsonRouteRepository jsonRepository, out Mock<IHttpClientFactory> httpClientFactoryMoq);

            var service = new RouteMatchingService(jsonRepository, httpClientFactoryMoq.Object, hereApiCredentialsOptions, new JsonRouteToGpxAdaptor());
            var routes = service.GetAll();

            Assert.NotEmpty(routes);
        }

        [Fact()]
        public async Task MatchRouteTest()
        {
            ServicePreparation(out IOptions<HereAPICredentials> hereApiCredentialsOptions, out JsonRouteRepository jsonRepository, out Mock<IHttpClientFactory> httpClientFactoryMoq);

            var service = new RouteMatchingService(jsonRepository, httpClientFactoryMoq.Object, hereApiCredentialsOptions, new JsonRouteToGpxAdaptor());
            var response = await service.MatchRoute(service.Get(1));

            Assert.NotNull(response);
            Assert.NotEmpty(response.TracePoints);
        }

        private void ServicePreparation(out IOptions<HereAPICredentials> hereApiCredentialsOptions, out JsonRouteRepository jsonRepository, out Mock<IHttpClientFactory> httpClientFactoryMoq)
        {
            var client = new HttpClient();
            hereApiCredentialsOptions = Options.Create(new HereAPICredentials() { AppId = "PXiCuHPaKy6hKqKV9Bb6", AppCode = "Mdwq9IojkCEoCmOuXdARcQ" });
            jsonRepository = new JsonRouteRepository();
            httpClientFactoryMoq = new Mock<IHttpClientFactory>();
            httpClientFactoryMoq.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
        }
    }
}