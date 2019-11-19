using Xunit;
using HereApiIntegration.Definitions.Options;
using Microsoft.Extensions.Options;

namespace HereApiIntegration.Repositories.Tests
{
    public class JsonWaypointsRepositoryTests
    {
        [Fact()]
        public void GetAllTest()
        {
            var someOptions = Options.Create(new JsonRepositoryPath() { Path = "FakeData" });
            var jsonWaypointsRepository = new JsonRouteRepository(someOptions);

            var waypoints = jsonWaypointsRepository.GetAll();

            Assert.NotEmpty(waypoints);
        }
    }
}