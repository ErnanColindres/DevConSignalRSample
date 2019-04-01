using System;
using System.Collections.Generic;
using System.Text;
using DevConSignalRBusinessAccessLayer.Services.Interfaces;
using DevConSignalRModels.Entities;
using DevConSignalRSampleDataAccessLayer.Repositories.Interfaces;

namespace DevConSignalRBusinessAccessLayer.Services
{
    public class VoteService : IVoteService
    {
        private readonly ICandidateRepository _candidaterespository;
        private readonly IVoteRepository _voterespository;

        public VoteService(ICandidateRepository candidaterepository, IVoteRepository voterepository)
        {
            _candidaterespository = candidaterepository;
            _voterespository = voterepository;
        }

        public bool Vote(Guid candidateId)
        {
            if (candidateId == Guid.Empty)
            {
                return false;
            }

            var candidate = _candidaterespository.Find(candidateId);

            if (candidate == null)
                return false;

            _voterespository.Create(new Vote
            {
                CandidateId = candidateId
            });

            _voterespository.Complete();

            return true;
        }
    }
}
