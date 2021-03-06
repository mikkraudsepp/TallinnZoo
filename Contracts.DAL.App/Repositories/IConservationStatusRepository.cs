using Contracts.DAL.Base.Repositories;
using Domain.Animals;

namespace Contracts.DAL.App.Repositories
{
    public interface IConservationStatusRepository : IBaseRepositoryAsync<ConservationStatus>
    {
    }
}