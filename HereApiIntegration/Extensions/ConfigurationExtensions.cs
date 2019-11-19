using HereApiIntegration.Definitions.Options;
using Microsoft.Extensions.Configuration;

namespace HereApiIntegration.Definitions.Extensions
{
    public static class ConfigurationExtensions
    {
        public static JsonRepositoryPath GetJsonRespositoryPath(this IConfiguration configuration)
        {
            var path = configuration[Consts.FakeDataPath];
          
            return new JsonRepositoryPath()
            {
                Path = path
            };
        }
    }
}
