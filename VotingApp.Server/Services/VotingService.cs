using VotingApp.Server.DTOs;
using VotingApp.Server.Models;
using VotingApp.Server.Services.Interfaces;

namespace VotingApp.Server.Services
{
    public class VotingService : IVotingService
    {
        private readonly DataManager _dataManager;

        public VotingService()
        {
            _dataManager = DataManager.Instance;
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            return await _dataManager.GetCandidates();
        }

        public async Task<List<Voter>> GetVoters()
        {
            return await _dataManager.GetVoters();
        }

        public async Task CastVote(CastVoteRequestDto castVoteRequest)
        {
            await _dataManager.CastVote(castVoteRequest);
        }

        public async Task<Guid> AddEntity(AddEntityRequestDto addEntityRequest)
        {
            switch (addEntityRequest.Type)
            {
                case EntityType.Candidate:
                    Candidate candidate = new Candidate
                    {
                        Id = Guid.NewGuid(),
                        Name = addEntityRequest.Name,
                        Votes = 0
                    };
                    await _dataManager.SaveCandidate(candidate);
                    return candidate.Id;
                case EntityType.Voter:
                    Voter voter = new Voter()
                    {
                        Id = Guid.NewGuid(),
                        Name = addEntityRequest.Name,
                        HasVoted = false
                    };
                    await _dataManager.SaveVoter(voter);
                    return voter.Id;
                default:
                    throw new BadHttpRequestException("Invalid entity type.");
            }
        }
    }
}
