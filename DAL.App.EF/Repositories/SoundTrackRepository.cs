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
    public class SoundTrackRepository : BaseRepository<SoundTrack>, ISoundTrackRepository
    {
        public SoundTrackRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}