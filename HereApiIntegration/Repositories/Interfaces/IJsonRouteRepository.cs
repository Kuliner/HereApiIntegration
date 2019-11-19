using HereApiIntegration.Model;
using System.Collections.Generic;

namespace HereApiIntegration.Repositories
{
    public interface IJsonRouteRepository
    {
        IEnumerable<JsonRoute> GetAll();
    }
}
