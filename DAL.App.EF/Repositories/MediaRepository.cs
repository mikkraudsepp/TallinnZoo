using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Animals;

namespace DAL.App.EF.Repositories
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        public MediaRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}