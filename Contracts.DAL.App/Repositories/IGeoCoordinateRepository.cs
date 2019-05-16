using Contracts.DAL.Base.Repositories;
using Domain.Map;

namespace Contracts.DAL.App.Repositories
{
    public interface IGeoCoordinateRepository : IBaseRepositoryAsync<GeoCoordinate>
    {
    }
}