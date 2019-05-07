

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
    public class SoundTrackService : BaseEntityService<SoundTrack, IAppUnitOfWork>, ISoundTrackService
    {
        public SoundTrackService(IAppUnitOfWork uow) : base(uow)
        {
            
        }
    }

}