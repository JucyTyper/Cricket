namespace Cricket.Models
{
    public class AddTeamPlayer
    {
        public  Guid TeamId { get; set; }
        public List<Guid> Players { get; set; }
    }
}
