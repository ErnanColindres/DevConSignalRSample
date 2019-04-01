using DevConSignalRModels.DTO;
using DevConSignalRModels.Entities;
using DevConSignalRSampleDataAccessLayer.Context;
using DevConSignalRSampleDataAccessLayer.Repositories.Base;
using DevConSignalRSampleDataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRSampleDataAccessLayer.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(MainDbContext context)
            : base (context)
        {  }

        public IEnumerable<CandidateVote> GetCandidateVotes()
        {
            return _dbContext.Set<CandidateVote>();
        }
    }
}
