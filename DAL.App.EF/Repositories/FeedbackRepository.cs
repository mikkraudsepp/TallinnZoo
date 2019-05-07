using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class FeedbackRepository: BaseRepository<Feedback>, IFeedbackRepository
    {

        public FeedbackRepository(IDataContext dataContext) : base(dataContext)
        {
        }

    }
}