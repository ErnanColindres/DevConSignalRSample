using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRBusinessAccessLayer.Services.Interfaces
{
    public interface IVoteService
    {
        bool Vote(Guid candidateId);
    }
}
