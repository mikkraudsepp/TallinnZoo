using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;
using Domain.Animals;
using Domain.Map;

namespace Contracts.BLL.App.Services
{
    public interface IGeoCoordinateService  : IBaseEntityService<GeoCoordinate>, IGeoCoordinateRepository
    {
        
    }
}
