using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain.Animals;

namespace DAL.App.EF.Repositories
{
    public class AnimalFactRepository : BaseRepository<AnimalFact>, IAnimalFactRepository
    {
        public AnimalFactRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}