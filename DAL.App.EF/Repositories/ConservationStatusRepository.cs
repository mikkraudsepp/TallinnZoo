using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain.Animals;

namespace DAL.App.EF.Repositories
{
    public class ConservationStatusRepository : BaseRepository<ConservationStatus>, IConservationStatusRepository
    {
        public ConservationStatusRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}