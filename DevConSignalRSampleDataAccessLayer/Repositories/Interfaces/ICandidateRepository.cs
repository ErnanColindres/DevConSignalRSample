using DevConSignalRModels.DTO;
using DevConSignalRModels.Entities;
using DevConSignalRSampleDataAccessLayer.Repositories.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRSampleDataAccessLayer.Repositories.Interfaces
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        IEnumerable<CandidateVote> GetCandidateVotes();

    }
}
