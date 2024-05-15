using VotingApp.Server.DTOs;
using VotingApp.Server.Models;

namespace VotingApp.Server.Services
{
    public class DataManager
    {
        private static readonly Lazy<DataManager> _instance = new Lazy<DataManager>(() => new DataManager());
        private static readonly object _lock = new object();

        public DataManager()
        {
            // Initialize data or perform other setup tasks
        }

        public static DataManager Instance => _instance.Value;

        private List<Candidate> Candidates { get; set; } = new List<Candidate>
        {
            new Candidate()
            {
                Id = Guid.NewGuid(),
                Name = "Narendra Modi",
                Votes = 0
            },
            new Candidate()
            {
                Id = Guid.NewGuid(),
                Name = "Rahul Gandhi",
                Votes = 0
            }
        };

        private List<Voter> Voters { get; set; } = new List<Voter>
        {
            new Voter()
            {
                Id = Guid.NewGuid(),
                Name = "John Cena",
                HasVoted = false,
            },
            new Voter()
            {
                Id = Guid.NewGuid(),
                Name = "Brock Lesnar",
                HasVoted = false,
            }
        };

        public async Task<List<Candidate>> GetCandidates()
        {
            return Candidates;
        }

        public async Task SaveCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public async Task<List<Voter>> GetVoters()
        {
            return Voters;
        }

        public async Task SaveVoter(Voter voter)
        {
            Voters.Add(voter);
        }

        public async Task CastVote(CastVoteRequestDto castVoteRequest)
        {
            Candidate? candidate = Candidates.Find(x => x.Id == castVoteRequest.CandidateId);

            if (candidate is null)
                throw new BadHttpRequestException("Candidate is not valid.");

            Voter? voter = Voters.Find(x => x.Id == castVoteRequest.VoterId);

            if (voter is null)
                throw new BadHttpRequestException("Voter is not valid.");

            if (voter.HasVoted is true)
                throw new BadHttpRequestException("Voter has already voted once.");

            candidate.Votes++;
            voter.HasVoted = true;
        }
    }
}
