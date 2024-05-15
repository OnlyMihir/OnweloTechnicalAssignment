using VotingApp.Server.DTOs;
using VotingApp.Server.Models;

namespace VotingApp.Server.Services.Interfaces
{
    public interface IVotingService
    {
        Task<List<Candidate>> GetCandidates();

        Task<List<Voter>> GetVoters();

        Task CastVote(CastVoteRequestDto castVoteRequest);

        Task<Guid> AddEntity(AddEntityRequestDto addEntityRequest);
    }
}
