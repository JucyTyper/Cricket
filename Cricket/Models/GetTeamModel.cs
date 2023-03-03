namespace Cricket.Models
{
    public class GetTeamModel
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public List<string> PlayerID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
