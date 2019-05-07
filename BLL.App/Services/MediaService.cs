

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using Domain.Animals;

namespace BLL.App.Services
{
    public class MediaService : BaseEntityService<Media, IAppUnitOfWork>, IMediaService
    {
        public MediaService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }

}
