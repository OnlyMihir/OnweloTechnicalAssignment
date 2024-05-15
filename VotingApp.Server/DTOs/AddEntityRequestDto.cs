namespace VotingApp.Server.DTOs
{
    public class AddEntityRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public EntityType Type { get; set; }
    }

    public enum EntityType
    {
        Candidate,
        Voter
    }
}
