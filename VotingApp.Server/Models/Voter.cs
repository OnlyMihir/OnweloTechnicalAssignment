namespace VotingApp.Server.Models
{
    public class Voter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasVoted { get; set; }
    }
}
