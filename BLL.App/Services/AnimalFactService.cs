

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain.Animals;

namespace BLL.App.Services
{
    public class AnimalFactService : BaseEntityService<AnimalFact, IAppUnitOfWork>, IAnimalFactService
    {
        public AnimalFactService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }

}
