namespace Cricket.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public Guid MatchID { get; set; }
    }
}
