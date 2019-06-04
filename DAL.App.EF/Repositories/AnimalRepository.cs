using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DAL.App.EF.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        /// <summary>
        /// Get all the records, include contacts
        /// </summary>
        /// <returns></returns>
        //public override async Task<IList<Animal>> AllAsync()
        //{
        //    return await RepositoryDbSet
        //        .Include(m => m.Name)
        //        .ThenInclude(t => t.Translations)
        //        .Select(e => new Animal
        //        {
        //            Id = e.Id,
        //            Name = e.Name,
        //            Description = e.Description,
        //            BinomialName = e.BinomialName,
        //            LastEdited = e.LastEdited,
        //            Created = e.Created,
        //            MapSegmentId = e.MapSegmentId,
        //            MapSegment = e.MapSegment,
        //            FeaturedImgId = e.FeaturedImgId,
        //            FeaturedImg = e.FeaturedImg,
        //            ConservationStatusId = e.ConservationStatusId,
        //            ConservationStatus = e.ConservationStatus,
        //            ScientificClassificationId = e.ScientificClassificationId,
        //            ScientificClassification = e.ScientificClassification,
        //            AnimalFacts = e.AnimalFacts,
        //            MediaInAnimals = e.MediaInAnimals,
        //            AnimalSoundTracks = e.AnimalSoundTracks
        //        }).ToListAsync<Animal>();
        //}


    }
}