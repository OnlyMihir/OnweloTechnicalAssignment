using Microsoft.AspNetCore.Mvc;
using VotingApp.Server.DTOs;
using VotingApp.Server.Models;
using VotingApp.Server.Services.Interfaces;

namespace VotingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly IVotingService _votingService;

        public VotingController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        [HttpGet]
        [Route("Candidates")]
        public async Task<List<Candidate>> GetCandidates()
        {
            return await _votingService.GetCandidates();
        }

        [HttpGet]
        [Route("Voters")]
        public async Task<List<Voter>> GetVoters()
        {
            return await _votingService.GetVoters();
        }

        [HttpPost]
        [Route("CastVote")]
        public async Task CastVote(CastVoteRequestDto castVoteRequest)
        {
            await _votingService.CastVote(castVoteRequest);
        }

        [HttpPost]
        [Route("AddEntity")]
        public async Task<Guid> AddEntity(AddEntityRequestDto addEntityRequest)
        {
            return await _votingService.AddEntity(addEntityRequest);
        }
    }
}
