using DevConSignalRBusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevConSignalRSample.Hubs
{
    public class VoteHub : Hub
    {
        private readonly IVoteService _voteService;

        public VoteHub(IVoteService voteService)
        {
            _voteService = voteService;
        }

        public async Task Vote (Guid candidateId, string message)
        {
            var result = _voteService.Vote(candidateId);

            if (result)
            {
                await Clients.All.SendAsync("NewVote", candidateId);
                await NotifyVoters(message);
            }
        }

        public async Task NotifyVoters(string message = null)
        {
            await Clients.Others.SendAsync("NotifyVoters", message);
        }
    }
}
