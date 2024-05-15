namespace VotingApp.Server.DTOs
{
    public class CastVoteRequestDto
    {
        public Guid CandidateId { get; set; }
        public Guid VoterId { get; set; }
    }
}
