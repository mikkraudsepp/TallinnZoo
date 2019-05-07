

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain.Animals;
using Domain.Map;

namespace BLL.App.Services
{
    public class AppMapService : BaseEntityService<AppMap, IAppUnitOfWork>, IAppMapService
    {
        public AppMapService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }

}
