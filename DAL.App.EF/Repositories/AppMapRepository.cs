using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain.Animals;
using Domain.Map;

namespace DAL.App.EF.Repositories
{
    public class AppMapRepository : BaseRepository<AppMap>, IAppMapRepository
    {
        public AppMapRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}