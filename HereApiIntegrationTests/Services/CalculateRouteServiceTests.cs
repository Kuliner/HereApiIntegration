using Xunit;
using Microsoft.Extensions.Options;
using HereApiIntegration.Definitions.Options;
using System.Net.Http;
using Moq;
using System.Collections.Generic;
using HereApiIntegration.Model;
using System.Threading.Tasks;

namespace HereApiIntegration.Services.Tests
{
    public class CalculateRouteServiceTests
    {
        [Fact()]
        public async Task CalculateRouteTest()
        {
            var client = new HttpClient();
            var hereApiCredentialsOptions = Options.Create(new HereAPICredentials() { AppId = "PXiCuHPaKy6hKqKV9Bb6", AppCode = "Mdwq9IojkCEoCmOuXdARcQ" });
            var httpClientFactoryMoq = new Mock<IHttpClientFactory>();
            var points = new List<Point>()
            {
                new Point()
                {
                    Longitude = 50,
                    Latitude = 10
                },
                new Point()
                {
                    Longitude = 51,
                    Latitude = 11
                }
            };

            httpClientFactoryMoq.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            var service = new CalculateRouteService(httpClientFactoryMoq.Object, hereApiCredentialsOptions);
            var result = await service.CalculateRoute(points, "pl-PL");

            Assert.NotEmpty(result.Response.Route[0].Waypoint);
        }
    }
}