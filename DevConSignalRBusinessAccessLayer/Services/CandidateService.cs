using DevConSignalRBusinessAccessLayer.Services.Interfaces;
using DevConSignalRModels.DTO;
using DevConSignalRSampleDataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRBusinessAccessLayer.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IEnumerable<CandidateVote> GetCandidateVotes()
        {
            return _candidateRepository.GetCandidateVotes();    
        }
    }
}
