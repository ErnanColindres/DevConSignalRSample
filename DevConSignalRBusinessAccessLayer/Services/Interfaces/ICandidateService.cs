using DevConSignalRModels.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRBusinessAccessLayer.Services.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateVote> GetCandidateVotes();
    }
}
