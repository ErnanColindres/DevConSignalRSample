using DevConSignalRModels.Entities;
using DevConSignalRSampleDataAccessLayer.Context;
using DevConSignalRSampleDataAccessLayer.Repositories.Base;
using DevConSignalRSampleDataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRSampleDataAccessLayer.Repositories
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(MainDbContext context)
            : base(context)
        {  }
    }
}
